
export const getNowShowingMovies = async () => {
  const fetchResponse = await fetch(
    import.meta.env.VITE_APP_API_HOST + "/Movies",
  );
  const data = await fetchResponse.json();
  return data;
};

export const getShowTimeByMovieNameAndDate = async (movieName: string, showDate: Date) => {
  const showDateString = showDate.toISOString().split('T')[0];
  const fetchResponse = await fetch(
    import.meta.env.VITE_APP_API_HOST + `/Show/ByDate?movieName=${encodeURIComponent(movieName)}&showDate=${encodeURIComponent(showDateString)}`,
  );
  if(fetchResponse.ok) {
    const data = await fetchResponse.json();
    console.log(data);
    return data;
  }
  return null;
};