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
    Alert
} from "reactstrap";

function EditEmployee (props) {
    const location = useLocation ();
    const navigate = useNavigate ();
    const params = useParams ();

    const [fields, uptextFields] = useState (
        {
            idempleado: '',
            name: '',
            lastname: '',
            celular: '',
            username: '',
            password: ''
        }
    );
    
    const [state, uptextState] = useState (
        {
            token: props.token,
            isSubmitted: false,
            error: false
        }
    );

    const editEndpoint = process.env.REACT_APP_END_POINT_EMPLEADOS;
    const editTemplate = process.env.REACT_APP_END_POINT_EMPLEADOS_ALL; 

    useEffect (() => {
        
        let url = editEndpoint + editTemplate + "/" + params.id

        axios.get (url, {
            headers: {
                'Accept': 'application/json',
                'Content-type': 'application/json',
                'Authorization': 'Bearer ' + props.token
            }
        })
        .then (response => {
            if (response.status === 200) {
                uptextFields (
                    {
                        idempleado: params.id,
                        name: response.data.name,
                        lastname: response.data.lastname,
                        celular: response.data.celular,
                        username: response.data.username,
                        password: response.data.pass
                    }
                )
            } else {
                uptextState (
                    {
                        error: true
                    }
                )
            }
        });


    }, [params, editEndpoint, editTemplate, props.token]);
    
    function handleChange (e) {
        uptextFields (
            {
                ...fields,
                [e.target.name]: e.target.value
            }
        );
    }

    function add (e) {
        let url = editEndpoint + editTemplate + "/" + params.id

        let data = {
            idempelado: params.id,
            name: fields.name,
            lastname: fields.lastname,
            celular: fields.celular,
            username: fields.username,
            pass: fields.password
        }
        
        axios.put (url, JSON.stringify (data), {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + state.token
            }
        })
        .then (response => {
            if (response.status === 200) {
                uptextState (
                    {
                        isSubmitted: true
                    }
                );

                return;
            }

            uptextState (
                {
                    error: true,
                }
            );
        }).catch (reason => {
            uptextState ({
                error: true
            })
        })
    }

    function deleteEmployee(e){
        e.preventDefault();
        let url = editEndpoint + editTemplate + "/" + params.id

        (url)

        axios.delete(url, {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + state.token
            }
        })
        .then (response => {
            if (response.status === 200) {
                uptextState (
                    {
                        isSubmitted: true
                    }
                );
                cancel();
                return;
            }

            uptextState (
                {
                    error: true,
                }
            );
        }).catch (reason => {
            uptextState ({
                error: true
            })
        })
    }

    function cancel (e) {
        navigate ('/ClientManagement');
    }


    if (fields.token === '') {
        return (
            <Navigate to = '/login' state={{from: location.pathname}} />
        )
    }

    return (
        <Container className="App">
                <h4 className="PageHeading">Enter employee infomation</h4>
                <Alert 
                    isOpen={state.isSubmitted} 
                    color={!state.error ? "success" : "warning"}
                    toggle={() => uptextState ({ isSubmitted: false })}
                >
                    {!state.error ? "Information was saved!" : "An error occurs while trying to uptext information"}
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
                            <Label for="name" sm={2}>Last Name</Label>
                            <Col sm={2}>
                                <Input type="text" name="lastname" onChange={handleChange} value={fields.lastname} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Celular</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="text" name="celular" value={fields.celular} onChange={handleChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>Username</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="text" name="username" onChange={handleChange} value={fields.username} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="name" sm={2}>password</Label>
                            <Col sm={2}>
                                <Input bsSize="md" type="password" name="password" onChange={handleChange} value={fields.password} />
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
                            <Col sm={1}>
                                <Button color="error" onClick={deleteEmployee} >Eliminar</Button>
                            </Col>
                            <Col sm={5}>
                            </Col>
                        </FormGroup>
                    </Col>
                </Form>
            </Container>
    );

}

export default EditEmployee;