import { Button, Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const HomePage = () => {
  const navigate = useNavigate();

  return (
    <Container className="text-center mt-5">
      <h1>Welcome to the Veterinary Clinic</h1>
      <h4>choose your service:</h4>
      <Button
        className="m-4"
        onClick={() => {
          navigate(`/Registry`);
        }}
      >
        Veterinary
      </Button>
      <Button
        className="m-4"
        onClick={() => {
          navigate(`/HomePharmacy`);
        }}
      >
        Pharmacy
      </Button>
    </Container>
  );
};

export default HomePage;
