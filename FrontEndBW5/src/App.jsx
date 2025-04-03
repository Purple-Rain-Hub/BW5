import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import MyNavbar from "./components/MyNavbar";
import AddAnimal from "./components/vetComponents/AddAnimal";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import GetAnimals from "./components/vetComponents/GetAnimals";

function App() {
  return (
    <>
      <BrowserRouter>
        <MyNavbar />
        <Routes>
          <Route path="/Registry" element={<GetAnimals />} />
          <Route path="/Registry/Add" element={<AddAnimal />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
