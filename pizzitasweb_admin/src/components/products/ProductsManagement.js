import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from 'react';

import { Alert, Container } from 'react-bootstrap';

function ProductsManagement() {

    const [state, setState] = useState ({
        products: [],
        isFetched: false
    });

    const basePath = process.env.REACT_APP_PRODUCTS_ENDPOINT_BASEPATH;
    const getAllEndPoint = process.env.REACT_APP_PRODUCTS_ENDPOINT_GETALL;

    useEffect (() => {
        let url = basePath + getAllEndPoint;

        fetch (url)
        .then ((response => response.json ()))
        .then ((json) => {
            setState ({
                products: json,
                isFetched: true
            });
        })
    });

    if (!state.isFetched) {
		return (
			<Container>
				<Alert color="primary">Loading...</Alert>
			</Container>
		);
	}

    return (
        <div>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Price</th>
                        <th>Quantity</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        state.products.map (product => 
                            <tr key={product.idproducto} >
                                <td>{product.name}</td>
                                <td>{product.descripcion}</td>
                                <td>{product.precio}</td>
                                <td>{product.quantity}</td>
                                <td><Button variant="info" href="/editproduct">Edit Product</Button></td>
                            </tr>
                        )
                    }
                </tbody>
            </Table>
            <hr />
            <Button variant="info" type="submit" href="/addproduct">
                Add Product
            </Button>

        </div>
    );
}

export default ProductsManagement;