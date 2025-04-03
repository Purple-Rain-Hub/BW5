import { useState } from "react";
import { Button, Container, Form } from "react-bootstrap";

const AddAnimal = () => {
  const [newAnimal, setNewAnimal] = useState({
    name: "",
    type: "",
    coatColor: "",
    birthDate: "",
    hasMicrochip: false,
    microchipNumber: "",
    ownerName: "",
    ownerSurname: "",
  });

  const postAnimal = async (newAnimal) => {
    const myToken =
      "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUGFvbG8gQm9ub2xpcyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NDM1NjI2LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.4s_6fd508fkuhfAh6B_xno8U5zEGEeIVtMT3Xe5EAEA";
    try {
      const response = await fetch("https://localhost:7030/api/Registry", {
        method: "POST",
        body: JSON.stringify(newAnimal),
        headers: {
          Authorization: "Bearer " + myToken,
          "Content-type": "application/json; charset=UTF-8",
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleNewAnimal = (e) => {
    e.preventDefault();
    if (newAnimal.microchipNumber == "") {
      newAnimal.microchipNumber = null;
    }
    if (newAnimal.name == "") {
      newAnimal.name = null;
    }
    if (newAnimal.birthDate == "") {
      newAnimal.birthDate = null;
    }
    if (newAnimal.ownerName == "") {
      newAnimal.ownerName = null;
    }
    if (newAnimal.ownerSurname == "") {
      newAnimal.ownerSurname = null;
    }
    postAnimal(newAnimal);

    setNewAnimal({
      name: "",
      type: "",
      coatColor: "",
      birthDate: "",
      hasMicrochip: false,
      microchipNumber: "",
      ownerName: "",
      ownerSurname: "",
    });
  };

  return (
    <Container>
      <h1>Aggiungi nuovo animale</h1>
      <Form onSubmit={handleNewAnimal}>
        <Form.Label className="mt-2 fw-lighter">Name</Form.Label>
        <Form.Control
          type="text"
          value={newAnimal.name}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              name: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Type</Form.Label>
        <Form.Control
          type="text"
          required
          value={newAnimal.type}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              type: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Coat Color</Form.Label>
        <Form.Control
          type="text"
          required
          value={newAnimal.coatColor}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              coatColor: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Birth Date</Form.Label>
        <Form.Control
          type="date"
          required
          value={newAnimal.birthDate.split("T")[0]}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              birthDate: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Has Microchip</Form.Label>
        <Form.Check
          value={newAnimal.hasMicrochip}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              hasMicrochip: e.target.checked,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Microchip Number</Form.Label>
        <Form.Control
          type="number"
          value={newAnimal.microchipNumber}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              microchipNumber: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Owner Name</Form.Label>
        <Form.Control
          type="text"
          value={newAnimal.ownerName}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
              ownerName: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Owner Surname</Form.Label>
        <Form.Control
          type="text"
          value={newAnimal.ownerSurname}
          onChange={(e) => {
            setNewAnimal({
              ...newAnimal,
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

export default AddAnimal;
