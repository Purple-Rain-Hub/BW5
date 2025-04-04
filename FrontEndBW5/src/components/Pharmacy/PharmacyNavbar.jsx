import { Link } from "react-router-dom";

function PharmacyNavbar() {
  return (
    <nav className="Pharmacy navbar-expand-lg navbar-dark bg-dark">
      <div className="container">
        <Link className="navbar-brand" to="/">
          Clinica Veterinaria
        </Link>
        <div className="collapse navbar-collapse">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <Link className="nav-link" to="/medicine">
                Medicine
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/sale">
                Sale
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/receipt">
                Receipt
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default PharmacyNavbar;
