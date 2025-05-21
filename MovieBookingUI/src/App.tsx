import { Routes } from "react-router";
import "./App.css";
import { Route } from "react-router";
import { MoviesList } from "./pages/Movies/Movies";
import { ShowList } from "./pages/Show/Show";

function App() {
 
  return (
    <>
        <div className="content">
          <Routes>
            <Route path="/Movies" element={<MoviesList />} />
            <Route path="/Shows" element={<ShowList />} />
          </Routes>
        </div>
    </>
  )
}

export default App
