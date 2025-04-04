import { useEffect, useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { useParams } from "react-router-dom";

const EditAnimal = () => {
  const id = useParams();
  const myToken =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUGFvbG8gQm9ub2xpcyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NDM1NjI2LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.4s_6fd508fkuhfAh6B_xno8U5zEGEeIVtMT3Xe5EAEA";
  const [message, setMessage] = useState();
  const [animal, setAnimal] = useState({
    name: "",
    type: "",
    coatColor: "",
    birthDate: "",
    hasMicrochip: false,
    microchipNumber: "",
    ownerName: "",
    ownerSurname: "",
  });

  const getAnimalById = async (id) => {
    try {
      const response = await fetch(
        "https://localhost:7030/api/Registry/" + id,
        {
          headers: {
            Authorization: "Bearer " + myToken,
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setAnimal(data.animal);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  useEffect(() => {
    getAnimalById(id.id);
  }, []);

  const putAnimal = async (animal, id) => {
    try {
      const response = await fetch(
        "https://localhost:7030/api/Registry?id=" + id,
        {
          method: "PUT",
          body: JSON.stringify(animal),
          headers: {
            Authorization: "Bearer " + myToken,
            "Content-type": "application/json; charset=UTF-8",
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setMessage(data.message);
        getAnimalById(id);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  const handleAnimal = (e) => {
    e.preventDefault();
    if (animal.microchipNumber == "") {
      animal.microchipNumber = null;
    }
    if (animal.name == "") {
      animal.name = null;
    }
    if (animal.birthDate == "") {
      animal.birthDate = null;
    }
    if (animal.ownerName == "") {
      animal.ownerName = null;
    }
    if (animal.ownerSurname == "") {
      animal.ownerSurname = null;
    }
    putAnimal(animal, id.id);
  };

  return (
    <Container>
      <h1>Add new animal</h1>
      <span className="bg-warning rounded-1">{message}</span>
      <Form onSubmit={handleAnimal}>
        <Form.Label className="mt-2 fw-lighter">Name</Form.Label>
        <Form.Control
          type="text"
          value={animal.name}
          onChange={(e) => {
            setAnimal({
              ...animal,
              name: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Type</Form.Label>
        <Form.Control
          type="text"
          required
          value={animal.type}
          onChange={(e) => {
            setAnimal({
              ...animal,
              type: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Coat Color</Form.Label>
        <Form.Control
          type="text"
          required
          value={animal.coatColor}
          onChange={(e) => {
            setAnimal({
              ...animal,
              coatColor: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Birth Date</Form.Label>
        <Form.Control
          type="date"
          required
          value={animal.birthDate.split("T")[0]}
          onChange={(e) => {
            setAnimal({
              ...animal,
              birthDate: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Has Microchip</Form.Label>
        <Form.Check
          value={animal.hasMicrochip}
          onChange={(e) => {
            setAnimal({
              ...animal,
              hasMicrochip: e.target.checked,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Microchip Number</Form.Label>
        <Form.Control
          type="number"
          value={animal.microchipNumber}
          onChange={(e) => {
            setAnimal({
              ...animal,
              microchipNumber: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Owner Name</Form.Label>
        <Form.Control
          type="text"
          value={animal.ownerName}
          onChange={(e) => {
            setAnimal({
              ...animal,
              ownerName: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Owner Surname</Form.Label>
        <Form.Control
          type="text"
          value={animal.ownerSurname}
          onChange={(e) => {
            setAnimal({
              ...animal,
              ownerSurname: e.target.value,
            });
          }}
        />
        <Button
          type="submit"
          className="btn rounded-pill border border-1 text-white px-3 py-1 fw-medium mt-3 ms-1"
        >
          Save
        </Button>
        <Button
          type="reset"
          className="btn rounded-pill border border-1 text-white px-3 py-1 fw-medium mt-3 ms-1"
        >
          Reset
        </Button>
      </Form>
    </Container>
  );
};

export default EditAnimal;
