import Table from 'react-bootstrap/Table';

function OrdersManagement() {
  return (
    
    <Table striped bordered hover>
      <thead >
        <tr>
          <th>ID Order</th>
          <th>Full Name</th>
          <th>Product</th>
          <th>Quantity</th>
          <th>Fecha</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>1</td>
          <td>Roberto Lagunes</td>
          <td>Pizza Peperoni</td>
          <td>5</td>
          <td>2022-12-12</td>
          <td>Entregado</td>
          <td><select name="status">
          <option selected>Selecciona una</option>
        <option>Pendiente</option>
        <option>En preparacion</option>
        <option>Enviado</option>
        <option>Entregado</option>
        </select></td>
        </tr>
        <tr>
        <td>2</td>
          <td>Lorenzo Alcocer</td>
          <td>Pizza Hawaina</td>
          <td>2</td>
          <td>2022-12-15</td>
          <td>En preparacion</td>
          <td><select name="status">
          <option selected>Selecciona una</option>
        <option>Pendiente</option>
        <option>En preparacion</option>
        <option>Enviado</option>
        <option>Entregado</option>
        </select></td>
        </tr>
        <tr>
        <td>3</td>
          <td>Eduardo Rios</td>
          <td>Pizza Cuatro Quesos</td>
          <td>1</td>
          <td>2022-12-19</td>
          <td>Entregado</td>
          <td><select name="status">
          <option selected>Selecciona una</option>
        <option>Pendiente</option>
        <option>En preparacion</option>
        <option>Enviado</option>
        <option>Entregado</option>
        </select></td>
        </tr>
      </tbody>
    </Table>
  );
}

export default OrdersManagement