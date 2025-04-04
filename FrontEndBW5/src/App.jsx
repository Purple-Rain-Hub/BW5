import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import MyNavbar from "./components/MyNavbar";
import AddAnimal from "./components/vetComponents/AddAnimal";
import AddExam from "./components/vetComponents/AddExam";
import EditAnimal from "./components/vetComponents/EditAnimal";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import GetAnimals from "./components/vetComponents/GetAnimals";
import AnimalExams from "./components/vetComponents/AnimalExams";
import EditExam from "./components/vetComponents/EditExam";

function App() {
  return (
    <>
      <BrowserRouter>
        <MyNavbar />
        <Routes>
          <Route path="/Registry" element={<GetAnimals />} />
          <Route path="/Registry/Add" element={<AddAnimal />} />
          <Route path="/Registry/Edit/:id" element={<EditAnimal />} />
          <Route path="/Exams/:id" element={<AnimalExams />}></Route>
          <Route path="/Exams/Add/:id" element={<AddExam />}></Route>
          <Route path="Exams/Edit/:id" element={<EditExam />}></Route>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
