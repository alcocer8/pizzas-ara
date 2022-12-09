import { useState } from "react";
import { Navigate, useLocation, useNavigate } from "react-router-dom";
import axios from "axios";

import {
  Col,
  Form,
  FormGroup,
  Button,
  Input,
  Label,
  Container,
  Alert,
} from "reactstrap";

const AddEmployee = ({ token }) => {
  const location = useLocation();
  const navigate = useNavigate();

  const [fields, uptextFields] = useState({
    idempleado: "",
    name: "",
    lastname: "",
    celular: "",
    username: "",
    password: "",
    cargo: 0,
  });

  const [state, uptextState] = useState({
    token: token,
    isSubmitted: false,
    error: false,
  });

  const editEndpoint = process.env.REACT_APP_END_POINT_EMPLEADOS;
  const editTemplate = process.env.REACT_APP_END_POINT_EMPLEADOS_ALL;

  function add(e) {
    let url = editEndpoint + editTemplate;

    let data = {
      idempleado: 0,
      name: fields.name,
      lastname: fields.lastname,
      username: fields.username,
      celular: fields.celular,
      pass: fields.password,
      cargo: fields.cargo,
    };

    axios
      .post(url, JSON.stringify(data), {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + state.token,
        },
      })
      .then((response) => {
        if (response.status === 200) {
          uptextState({
            isSubmitted: true,
          });

          return;
        }

        uptextState({
          error: true,
          isSubmitted: false,
        });
      })
      .catch((reason) => {
        uptextState({
          error: true,
        });
      });
  }

  function cancel(e) {
    navigate("/employeesManagement");
  }

  function handleChange(e) {
    uptextFields({
      ...fields,
      [e.target.name]: e.target.value,
    });
  }

  function handleCargo(e){
    let cargo = e.target.value;
    if(!cargo){
        return
    }
    fields.cargo = cargo
  }

  if (token === "") {
    return <Navigate to="/login" state={{ from: location.pathname }} />;
  }

  return (
    <Container className="App">
      <h4 className="PageHeading">Enter employee infomation</h4>
      <Alert
        isOpen={state.isSubmitted}
        color={!state.error ? "success" : "warning"}
        toggle={() => uptextState({ isSubmitted: false })}
      >
        {!state.error
          ? "Information was saved!"
          : "An error occurs while trying to uptext information"}
      </Alert>
      <Form className="form">
        <Col>
          <FormGroup row>
            <Label for="name" sm={2}>
              Nombre
            </Label>
            <Col sm={2}>
              <Input
                type="text"
                name="name"
                onChange={handleChange}
                value={fields.name}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="name" sm={2}>
              Apellido
            </Label>
            <Col sm={2}>
              <Input
                type="text"
                name="lastname"
                onChange={handleChange}
                value={fields.lastname}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="name" sm={2}>
              celular
            </Label>
            <Col sm={2}>
              <Input
                bsSize="md"
                type="text"
                name="celular"
                value={fields.celular}
                onChange={handleChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="name" sm={2}>
              Username
            </Label>
            <Col sm={2}>
              <Input
                bsSize="md"
                type="text"
                name="username"
                value={fields.username}
                onChange={handleChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="name" sm={2}>
              Password
            </Label>
            <Col sm={2}>
              <Input
                bsSize="md"
                type="password"
                name="password"
                onChange={handleChange}
                value={fields.password}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="cargo" sm={2}>
              Cargo
            </Label>
            <Col sm={2}>
              <select onChange={(e) => handleCargo(e)} >
                <option value="0" disabled >-- Selecionar --</option>
                <option value="2">Gerente</option>
                <option value="3">Cocinero</option>
                <option value="4">Repartidor</option>
              </select>
            </Col>
          </FormGroup>
        </Col>
        <Col>
          <FormGroup row>
            <Col sm={5}></Col>
            <Col sm={1}>
              <Button color="primary" onClick={add}>
                Submit
              </Button>
            </Col>
            <Col sm={1}>
              <Button color="secondary" onClick={cancel}>
                Cancel
              </Button>
            </Col>
            <Col sm={5}></Col>
          </FormGroup>
        </Col>
      </Form>
    </Container>
  );
};

export default AddEmployee;
