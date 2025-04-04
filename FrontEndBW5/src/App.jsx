import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
// import MyNavbar from "./components/MyNavbar";
import PharmacyNavbar from "./components/Pharmacy/PharmacyNavbar"
import HomePagePharmacy from './pages/HomePagePharmacy'
import MedicinePage from './pages/MedicinePage'
import SalePage from './pages/SalePage'
import ReceiptPage from './pages/ReceiptPage'

function App() {
  return (
    <Router>
      <PharmacyNavbar/>
      <div className="container mt-4">
        <Routes>
          <Route path="/" element={<HomePagePharmacy />} />
          <Route path="/medicine" element={<MedicinePage />} />
          <Route path="/sale" element={<SalePage />} />
          <Route path="/receipt" element={<ReceiptPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
