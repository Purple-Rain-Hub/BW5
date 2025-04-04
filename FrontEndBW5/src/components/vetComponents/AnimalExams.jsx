import { useEffect, useState } from "react";
import { Button, Container } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";

const AnimalExams = () => {
  const id = useParams();
  const navigate = useNavigate();
  const myToken =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUGFvbG8gQm9ub2xpcyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NDM1NjI2LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.4s_6fd508fkuhfAh6B_xno8U5zEGEeIVtMT3Xe5EAEA";
  const [message, setMessage] = useState();
  const [exams, setExams] = useState();

  const getAnimalExams = async (id) => {
    try {
      const response = await fetch(
        "https://localhost:7030/api/Exams/Animal/Exams/" + id,
        {
          method: "GET",
          headers: {
            Authorization: "Bearer " + myToken,
            "Content-type": "application/json; charset=UTF-8",
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setExams(data.exams);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  const deleteExamAsync = async (id) => {
    try {
      const response = await fetch("https://localhost:7030/api/Exams/" + id, {
        method: "DELETE",
        headers: {
          Authorization: "Bearer " + myToken,
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setMessage(data.message);
        getAnimalExams();
      } else throw new Error();
    } catch (error) {
      console.error(error);
    }
  };

  const deleteExam = (id) => {
    deleteExamAsync(id);
  };

  useEffect(() => {
    getAnimalExams(id.id);
  }, []);

  return (
    <Container>
      <span className="bg-warning rounded-1">{message}</span>
      {exams && (
        <>
          <h1>{exams[0].animalName}'s Exams</h1>
          <Button
            onClick={() => {
              navigate(`/Exams/Add/${id.id}`);
            }}
          >
            Add a new exam
          </Button>
          <table className="table table-bordered table-hover">
            <thead className="thead-dark ">
              <tr className="text-center centroTab">
                <th>Exam Id</th>
                <th>Exam Date</th>
                <th>Objective</th>
                <th>Treatment</th>
                <th>Vet Email</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {exams.map((a) => {
                return (
                  <tr key={a.id}>
                    <td>{a.id}</td>
                    <td>{a.examDate}</td>
                    <td>{a.examObjective}</td>
                    <td>{a.examTreatment}</td>
                    <td>{a.vetName}</td>
                    <td className="d-flex border-0">
                      <Button
                        onClick={() => {
                          navigate(`/Exams/Edit/${a.id}`);
                        }}
                      >
                        Edit
                      </Button>
                      <Button
                        type="button"
                        onClick={(e) => {
                          e.preventDefault();
                          deleteExam(a.id);
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
        </>
      )}
    </Container>
  );
};

export default AnimalExams;
