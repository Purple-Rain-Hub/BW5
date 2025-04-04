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
import PharmacyNavbar from "./components/Pharmacy/PharmacyNavbar";
import HomePage from "./pages/HomePage";
import MedicinePage from "./pages/MedicinePage";
import SalePage from "./pages/SalePage";
import ReceiptPage from "./pages/ReceiptPage";

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
          <Route path="/" element={<HomePage />} />
          <Route path="/medicine" element={<MedicinePage />} />
          <Route path="/sale" element={<SalePage />} />
          <Route path="/receipt" element={<ReceiptPage />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
