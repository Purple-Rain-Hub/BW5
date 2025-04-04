import { useEffect, useState } from "react";
import { Button, Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const GetAnimals = () => {
  const myToken =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUGFvbG8gQm9ub2xpcyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NDM1NjI2LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.4s_6fd508fkuhfAh6B_xno8U5zEGEeIVtMT3Xe5EAEA";

  const [animals, setAnimals] = useState();
  const [message, setMessage] = useState();

  const navigate = useNavigate();

  const getAnimals = async () => {
    try {
      const response = await fetch("https://localhost:7030/api/Registry", {
        method: "GET",
        headers: {
          Authorization: "Bearer " + myToken,
          "Content-type": "application/json; charset=UTF-8",
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setAnimals(data.animals);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  const deleteAnimalAsync = async (id) => {
    try {
      const response = await fetch(
        "https://localhost:7030/api/Registry/" + id,
        {
          method: "DELETE",
          headers: {
            Authorization: "Bearer " + myToken,
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setMessage(data.message);
        getAnimals();
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  const deleteAnimal = (id) => {
    deleteAnimalAsync(id);
  };

  useEffect(() => {
    getAnimals();
  }, []);

  return (
    <Container>
      <h1>Animal's Registry</h1>
      <span className="bg-warning rounded-1">{message}</span>
      {animals && (
        <table className="table table-bordered table-hover">
          <thead className="thead-dark ">
            <tr className="text-center centroTab">
              <th>Id</th>
              <th>Name</th>
              <th>Type</th>
              <th>Coat Color</th>
              <th>Has Microchip</th>
              <th>Microchip Number</th>
              <th>Owner</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {animals.map((a) => {
              return (
                <tr key={a.id}>
                  <td>{a.id}</td>
                  <td>{a.name}</td>
                  <td>{a.type}</td>
                  <td>{a.coatColor}</td>
                  <td>{a.hasMicrochip ? "yes" : "no"}</td>
                  <td>{a.microchipNumber == null ? "-" : a.microchipNumber}</td>
                  <td>
                    {a.ownerName} {a.ownerSurname}
                  </td>
                  <td className="d-flex border-0">
                    <Button
                      onClick={() => {
                        navigate(`/Exams/${a.id}`);
                      }}
                    >
                      Exams
                    </Button>
                    <Button
                      onClick={() => {
                        navigate(`/Registry/Edit/${a.id}`);
                      }}
                    >
                      Edit
                    </Button>
                    <Button
                      type="button"
                      onClick={(e) => {
                        e.preventDefault();
                        deleteAnimal(a.id);
                      }}
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      )}
    </Container>
  );
};

export default GetAnimals;
