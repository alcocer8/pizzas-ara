import React, { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';

function EditEmployees(props) {

    const [fields, setFields] = useState({
        employeeID: 0,
        employeeName: '',
        employeeLastName: '',
        cellphone: '',
        username: '',
        position: 0
    });

    useEffect(() => {
        let url = process.env.REACT_APP_EMPLOYEES_ENDPOINT_BASEPATH + process.env.REACT_APP_EMPLOYEES_ENDPOINT_GETALL + '/2';

        fetch (url)
        .then ((response => response.json ()))
        .then ((json) => {
            setFields ({
                employeeID: json.idempleado,
                employeeName: json.name,
                employeeLastName: json.lastname,
                cellphone: json.celular,
                username: json.username,
                position: json.idcargo
            });
        })
    });

    return (
        <div>

            <hr />
            <h2 className='d-flex justify-content-center'>Update Employee Information</h2>
            <div className='d-flex justify-content-center'>
                <Form className='rounded p-4 p-sm-3'>
                    <Form.Group as={Col}>
                        <Form.Label>First Name:</Form.Label>
                        <Form.Control type='name' value={fields.employeeName}/>
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Last Name:</Form.Label>
                        <Form.Control type='text' value={fields.employeeLastName} />
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Cellphone:</Form.Label>
                        <Form.Control type='text' value={fields.cellphone} />
                    </Form.Group>

                    <Form.Group as={Col}>
                        <Form.Label>Username:</Form.Label>
                        <Form.Control type='text' value={fields.username} />
                    </Form.Group>

                    <Form.Group as={Col}>
                        <Form.Label>Password</Form.Label>
                        <Form.Control type='password' />
                    </Form.Group>
                    <hr/>
                        <Form.Label>Cargo <select name='status' value={fields.position}>
                            <option value={1}>Administrador</option>
                            <option value={2}>Gerente</option>
                            <option value={3}>Cocinero</option>
                            <option value={4}>Repartidor</option>
                        </select>
                        </Form.Label>
                        <hr/>
                <Button variant='warning' type='submit'>
                    Update Employee
                </Button>
                <Button variant='danger' type='submit'>
                    Delete
                </Button>
                <Button variant='secondary' type='submit' href='/employees'>
                    Cancel
                </Button>
            </Form>
        </div>

        </div >

    );
}
export default EditEmployees;