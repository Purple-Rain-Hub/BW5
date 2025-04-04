import { useNavigate } from "react-router-dom";

function HomePagePharmacy() {
  const navigate = useNavigate();

  return (
    <div className="text-center mt-5">
      <h1>Benvenuto nella Farmacia della Clinica Veterinaria</h1>
      <p>Scegli una sezione dal menu per iniziare.</p>

      <div className="mt-4 d-flex justify-content-center gap-3">
        <button
          className="btn btn-primary"
          onClick={() => navigate("/medicine")}
        >
          Sezione Medicine
        </button>
        <button className="btn btn-success" onClick={() => navigate("/sale")}>
          Sezione Vendite
        </button>
        <button
          className="btn btn-warning"
          onClick={() => navigate("/receipt")}
        >
          Sezione Ricevute
        </button>
      </div>
    </div>
  );
}

export default HomePagePharmacy;
