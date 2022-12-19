import React from 'react'
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';


function EditEmployees() {
    return (
        <div>

            <hr />
            <h2 className='d-flex justify-content-center'>Update Employee Information</h2>
            <div className='d-flex justify-content-center'>
                <Form className='rounded p-4 p-sm-3'>
                    <Form.Group as={Col}>
                        <Form.Label>Firs Name:</Form.Label>
                        <Form.Control type="name" />
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Last Name:</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Cellphone:</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>

                    <Form.Group as={Col}>
                        <Form.Label>Username:</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>

                    <Form.Group as={Col}>
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" />
                    </Form.Group>
                    <hr/>
                        <Form.Label>Cargo <select name="status">
                            <option selected>Gerente</option>
                            <option>Jefe</option>
                            <option>Empleado</option>
                            <option>Repartidor</option>
                        </select>
                        </Form.Label>
                        <hr/>
                <Button variant="info" type="submit">
                    Update Employee
                </Button>
                <Button variant="danger" type="submit">
                    Delete
                </Button>
                <Button variant="warning" type="submit" href="/employees">
                    Cancel
                </Button>
            </Form>
        </div>

        </div >

    );
}
export default EditEmployees