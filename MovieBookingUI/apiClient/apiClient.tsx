
export const getNowShowingMovies = async () => {
  const fetchResponse = await fetch(
    import.meta.env.VITE_APP_API_HOST + "/Sighting",
  );
  const data = await fetchResponse.json();
  return data;
};