import { useEffect, useState } from "react";
import "./Movies.css";
import type { Movies } from "../../models/apiModels";
import { getNowShowingMovies } from "../../apiClient/apiClient";
import 'bootstrap/dist/css/bootstrap.min.css';

export const MoviesList = () => {
  const [showingMovies, setShowingMovies] = useState<Movies[]>();

  // API call to fetch movies now showing
  useEffect(() => {
    const getMoviesList = async () => {
      try {
        const response = await getNowShowingMovies();
        setShowingMovies(response);
      } catch (error) {
        console.log("An error occurred : " + error);
      }
    };
    getMoviesList();
  }, []);

  return (
    <div id="MoviesListContainer">
      <h1> Select a movie </h1>

      {showingMovies && (
       <div className="movies-container">
            <div className="d-flex overflow-auto" style={{ whiteSpace: 'nowrap' }}>
                {showingMovies?.map((movie) => (
                 <div key={movie.movieId} className="card text-bg-dark me-3 card-hover-effect">
                    <img src={movie.movieImageUrl} className="card-img" />
                    <br></br>
                    <div className="card-text">
                        <p>{movie.movieName}</p>
                    </div>
                </div>
                ))}
            </div>
        </div>
      )}

    </div>
  );
};