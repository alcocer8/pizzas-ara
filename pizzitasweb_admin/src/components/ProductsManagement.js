import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

function ProductsManagement() {
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
                    <tr>
                        <td>Pizza Peperoni</td>
                        <td>Clasica de Peperoni</td>
                        <td>99</td>
                        <td>1</td>
                        <td><a href="/editproduct">Edit Product</a></td>
                    </tr>
                    <tr>
                        <td>Pizza Hawaiana</td>
                        <td>Clasica de Hawaina</td>
                        <td>120</td>
                        <td>4</td>
                        <td><a href="/editproduct">Edit Product</a></td>
                    </tr>
                    <tr>
                        <td>Pizza Cuatro Quesos</td>
                        <td>Clasica de Quesos</td>
                        <td>130</td>
                        <td>10</td>
                        <td><a href="/editproduct">Edit Product</a></td>
                    </tr>
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