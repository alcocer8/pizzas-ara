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
    Alert
} from "reactstrap";

const AddProducto = ({token}) => {
    const location = useLocation ();
    const navigate = useNavigate ();
    
    const [fields, updateFields] = useState (
        {
            idproducto: 0,
            name: '',
            descripcion: '',
            precio: '',
            quantity: ''
        }
    );

    const [state, updateState] = useState (
        {
            token: token,
            isSubmitted: false,
            error: false
        }
    );

    const editEndpoint = process.env.REACT_APP_END_POINT_PRODUCTO;
    const editTemplate = process.env.REACT_APP_END_POINT_PRODUCTO_ALL;

    function add (e) {
        let url = editEndpoint + editTemplate;

        let data = {
            idproducto: 0,
            name: fields.name,
            descripcion: fields.descripcion,
            quantity: fields.quantity,
            precio: fields.precio
        }

        axios.post (url, JSON.stringify (data), {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + state.token
            }
        })
        .then (response => {
            if (response.status === 200) {
                updateState (
                    {
                        isSubmitted: true
                    }
                );

                return;
            }

            updateState (
                {
                    error: true,
                    isSubmitted: false
                }
            );
        }).catch (reason => {
            updateState (
                {
                    error: true
                }
            )
        })
    }

    function cancel (e) {
        navigate ('/productosManagement');
    }

    function handleChange (e) {
        updateFields (
            {
                ...fields,
                [e.target.name]: e.target.value
            }
        );
    }

    if (token === '') {
        return (
            <Navigate to = '/login' state = {{from: location.pathname}} />
        );
    }

    return (
        <Container className="App">
                <h4 className="PageHeading">Ingresa informacion del producto</h4>
                <Alert 
                    isOpen={state.isSubmitted} 
                    color={!state.error ? "success" : "warning"}
                    toggle={() => updateState ({ isSubmitted: false })}
                >
                    {!state.error ? "Information was saved!" : "An error occurs while trying to update information"}
                </Alert>
                <Form className="form">
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={2}>
                                <Input type="text" name="name" onChange={handleChange} value={fields.name} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Description</Label>
                            <Col sm={2}>
                                <Input type="text" name="descripcion" onChange={handleChange} value={fields.descripcion} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>precio</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="text" name="precio" value={fields.precio} onChange={handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Cantidad</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="number" name="quantity" value={fields.quantity} onChange={handleChange} />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}>
                            </Col>
                            <Col sm={1}>
                                <Button color="primary" onClick={add}>Submit</Button>
                            </Col>
                            <Col sm={1}>
                                <Button color="secondary" onClick={cancel} >Cancel</Button>
                            </Col>
                            <Col sm={5}>
                            </Col>
                        </FormGroup>
                    </Col>
                </Form>
            </Container>
    );

}

export default AddProducto;