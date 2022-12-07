import axios from "axios";
import { useEffect, useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";

import { Navigate } from "react-router-dom";

import {
  Container,
  FormGroup,
  Col,
  Input,
  Button,
  Form,
  Label,
  Alert,
} from "reactstrap";

function EditProducto(props) {
  const location = useLocation();
  const navigate = useNavigate();
  const params = useParams();

  const [fields, updateFields] = useState({
    idproducto: 0,
    name: "",
    descripcion: "",
    precio: "",
    quantity: ""
  });

  const [state, updateState] = useState({
    token: props.token,
    isSubmitted: false,
    error: false,
  });

  const editEndpoint = process.env.REACT_APP_END_POINT_PRODUCTO;
  const editTemplate = process.env.REACT_APP_END_POINT_PRODUCTO_ALL;

  useEffect(() => {
    let url = editEndpoint + editTemplate + "/" + params.id;

    axios
      .get(url, {
        headers: {
          Accept: "application/json",
          "Content-type": "application/json",
          Authorization: "Bearer " + props.token,
        },
      })
      .then((response) => {
        if (response.status === 200) {

          
          updateFields({
            idproducto: response.data.idproducto,
            name: response.data.name,
            descripcion: response.data.descripcion,
            precio: response.data.precio,
            quantity: response.data.quantity
          });
        } else {
          updateState({
            error: true,
          });
        }
      });
  }, [params, editEndpoint, editTemplate, props.token]);

  function handleChange(e) {
    updateFields({
      ...fields,
      [e.target.name]: e.target.value,
    });
  }

  function add(e) {
    let url = editEndpoint + editTemplate + "/" + params.id;

    let data = {
      name: fields.name,
      descripcion: fields.descripcion,
      precio: fields.precio,
      quantity: fields.quantity
    };

    axios
      .put(url, JSON.stringify(data), {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + state.token,
        },
      })
      .then((response) => {
        console.log(response)
        if (response.status === 200) {
          updateState({
            isSubmitted: true,
          });

          return;
        }

        updateState({
          error: true,
        });
      })
      .catch((reason) => {
        updateState({
          error: true,
        });
      });
  }

  /*
  function deleteProducto(e) {
    let url = editEndpoint + editTemplate + "/" + params.id;

    console.log(url);
    axios
      .post(url, {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + state.token,
        },
      })
      .then((response) => {
        if (response.status === 200) {
          updateState({
            isSubmitted: true,
          });

          cancel();
          return;
        }

        updateState({
          error: true,
        });
      })
      .catch((reason) => {
        updateState({
          error: true,
        });
      });
  }*/

  function cancel(e) {
    navigate("/productosManagement");
  }

  if (fields.token === "") {
    return <Navigate to="/login" state={{ from: location.pathname }} />;
  }

  return (
    <Container className="App">
      <h4 className="PageHeading">Enter producto infomation</h4>
      <Alert
        isOpen={state.isSubmitted}
        color={!state.error ? "success" : "warning"}
        toggle={() => updateState({ isSubmitted: false })}
      >
        {!state.error
          ? "Information was saved!"
          : "An error occurs while trying to update information"}
      </Alert>
      <Form className="form">
        <Col>
          <FormGroup row>
            <Label for="name" sm={2}>
              Nombre Producto
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
              Descripcion
            </Label>
            <Col sm={2}>
              <Input
                type="text"
                name="descripcion"
                onChange={handleChange}
                value={fields.descripcion}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="name" sm={2}>
              Precio
            </Label>
            <Col sm={2}>
              <Input
                bsSize="md"
                type="number"
                name="precio"
                step=".01"
                value={fields.precio}
                onChange={handleChange}
              />
            </Col>
          </FormGroup>
          <FormGroup row>
            <Label for="name" sm={2}>
              Cantidad
            </Label>
            <Col sm={2}>
              <Input
                bsSize="md"
                type="number"
                name="quantity"
                onChange={handleChange}
                value={fields.quantity}
              />
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
            {/* <Col sm={1}>
              <Button color="secondary" onClick={deleteProducto}>
                Delte
              </Button>
            </Col> */}
            <Col sm={5}></Col>
          </FormGroup>
        </Col>
      </Form>
    </Container>
  );
}

export default EditProducto;
