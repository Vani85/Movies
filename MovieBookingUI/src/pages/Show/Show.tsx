import { useEffect, useState } from "react";
import "./Show.css";
import type { Show } from "../../models/apiModels";
import { getShowTimeByMovieNameAndDate } from "../../apiClient/apiClient";
import 'bootstrap/dist/css/bootstrap.min.css';

export const ShowList = () => {
  const [shows, setShows] = useState<Show[]>();
  const [selectedDate, setSelectedDate] = useState<Date>(new Date());

  useEffect(() => {
    const getShowTime = async () => {
      try {
        const response = await getShowTimeByMovieNameAndDate("Lilo & Stitch",selectedDate);
        setShows(response);
      } catch (error) {
        console.log("An error occurred : " + error);
      }
    };
    getShowTime();
  }, [selectedDate]);

    // Generate an array of the next 7 days
  const generateNext7Days = () => {
    const dates = [];
    const today = new Date();
    for (let i = 0; i < 7; i++) {
      const nextDate = new Date(today);
      nextDate.setDate(today.getDate() + i);
      dates.push(nextDate);
    }
    return dates;
  };

  const handleDateClick = (date: Date) => {
    setSelectedDate(date);
  };

  const next7Days = generateNext7Days();

  return (
    <div id="ShowListContainer">
      <div className="date-picker">
        <h1>Select a Date</h1>
        <div className="date-list">
            {next7Days.map((date, index) => (
            <button
                key={index}
                className={`date-button ${
                selectedDate?.toDateString() === date.toDateString() ? "selected" : ""
                }`}
                onClick={() => handleDateClick(date)}
            >
                {new Date(date).toLocaleDateString('en-GB', { day: '2-digit', month: '2-digit' })}
            </button>
            ))}
        </div>
    </div>

      {shows && (
       <div className="shows-container">
            <div className="d-flex overflow-auto" style={{ whiteSpace: 'nowrap' }}>
                {shows?.map((show) => (
                 <div key={show.showId} className="card text-bg-dark me-3 card-hover-effect">                    
                    <div className="card-text">
                        <p>{show.showTime}</p>     
                    </div>

                    <div className="card-text">
                        <p>{show.theatre.theatreName}</p>      
                    </div>
                </div>
                ))}
            </div>
        </div>
      )}

    </div>
  );
};