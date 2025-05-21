export interface Movies {
  movieId: number;
  movieName: number;
  description: string;
  movieImageUrl: string;
  language: string;
  cast: string;
  director: string;
  releaseDate: string;
  durationInMins: number;
  isNowShowing: boolean;
}

export interface Theatre {
    theatreId: number;
    theatreName: string
    numberOfSeats: number;
}

export interface TheatreSeats {
    seatId: number;
    theatre: Theatre;
    row: string
    column: number;
    seatName: string;
    costInPounds: number;
}


export interface Show {
    showId: number;
    movies: Movies;
    theatre: Theatre;
    showDate: Date;
    showTime: string;
}