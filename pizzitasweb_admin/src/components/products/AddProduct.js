import React from 'react'
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';


function AddProduct() {
    return (
        <div>
            <hr />
            <h2 className='d-flex justify-content-center'>Add Product Information</h2>
            <div className='d-flex justify-content-center'>
                <Form className='rounded p-4 p-sm-3'>
                    <Form.Group as={Col}>
                        <Form.Label>Name Product:</Form.Label>
                        <Form.Control type="name" />
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Description:</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>
                    <Form.Group as={Col}>
                        <Form.Label>Price:</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>

                    <Form.Group as={Col}>
                        <Form.Label>Quantity:</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>
                        <hr/>
                <Button variant="info" type="submit">
                    Add Product
                </Button>
                <Button variant="danger" type="submit">
                    Delete
                </Button>
                <Button variant="warning" type="submit" href="/productsmanagement">
                    Cancel
                </Button>
            </Form>
        </div>

        </div >

    );
}
export default AddProduct