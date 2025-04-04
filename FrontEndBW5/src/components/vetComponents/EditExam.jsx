import { useEffect, useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { useParams } from "react-router-dom";

const EditExam = () => {
  const id = useParams();
  const myToken =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUGFvbG8gQm9ub2xpcyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzQ5NDM1NjI2LCJpc3MiOiJodHRwczovL3N0dWRlbnRBcGkuY29tIiwiYXVkIjoiaHR0cHM6Ly9zdHVkZW50QXBpLmNvbSJ9.4s_6fd508fkuhfAh6B_xno8U5zEGEeIVtMT3Xe5EAEA";
  const [message, setMessage] = useState();
  const [Exam, setExam] = useState({
    examDate: "",
    examObjective: "",
    examTreatment: "",
    vetId: "",
    vetName: "",
  });
  const [vets, setVets] = useState([]);

  const getExamById = async (id) => {
    try {
      const response = await fetch("https://localhost:7030/api/Exams/" + id, {
        headers: {
          Authorization: "Bearer " + myToken,
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setExam(data.exam);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  const getVets = async () => {
    try {
      const response = await fetch("https://localhost:7030/api/Account/Users", {
        method: "GET",
        headers: {
          Authorization: "Bearer " + myToken,
          "Content-type": "application/json; charset=UTF-8",
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        setVets(data.users);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  useEffect(() => {
    getExamById(id.id);
    getVets();
  }, []);

  const putExam = async (Exam, id) => {
    try {
      const response = await fetch(
        "https://localhost:7030/api/Exams?id=" + id,
        {
          method: "PUT",
          body: JSON.stringify(Exam),
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
        getExamById(id);
      } else throw new Error();
    } catch (error) {
      console.error(error);
      setMessage("error");
    }
  };

  const handleExam = (e) => {
    e.preventDefault();
    putExam(Exam, id.id);
  };

  return (
    <Container>
      <h1>Edit Exam</h1>
      <span className="bg-warning rounded-1">{message}</span>
      <Form onSubmit={handleExam}>
        <Form.Label className="mt-2 fw-lighter">Exam Date</Form.Label>
        <Form.Control
          type="date"
          required
          value={Exam.examDate.split("T")[0]}
          onChange={(e) => {
            setExam({
              ...Exam,
              examDate: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Objective</Form.Label>
        <Form.Control
          type="text"
          required
          value={Exam.examObjective}
          onChange={(e) => {
            setExam({
              ...Exam,
              examObjective: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Treatment</Form.Label>
        <Form.Control
          type="text"
          required
          value={Exam.examTreatment}
          onChange={(e) => {
            setExam({
              ...Exam,
              examTreatment: e.target.value,
            });
          }}
        />
        <Form.Label className="mt-2 fw-lighter">Veterinary</Form.Label>
        <Form.Select
          value={Exam.vetId}
          onChange={(e) => {
            setExam({
              ...Exam,
              vetId: e.target.value,
            });
          }}
        >
          <option value={Exam.vetId}>{Exam.vetName}</option>
          {vets
            .filter((v) => v.role == "Veterinary" && v.id != Exam.vetId)
            .map((v) => {
              return (
                <option value={v.id}>
                  {v.firstName} {v.lastName}
                </option>
              );
            })}
        </Form.Select>
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

export default EditExam;
