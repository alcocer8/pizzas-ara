import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
function Employees() {
  return (
    <div>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Cellphone</th>
            <th>Username</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>

          <tr>
            <td>Lorenzo</td>
            <td>Alcocer</td>
            <td>2291304567</td>
            <td>lore</td>
            <td><a href="/editemployees">Edit Employee</a></td>
          </tr>

          <tr>
            <td>Roberto</td>
            <td>Lagunes</td>
            <td>2299533808</td>
            <td>rober</td>
            <td><a href="/editemployees">Edit Employee</a></td>
          </tr>

          <tr>
            <td>Eduardo</td>
            <td>Rios</td>
            <td>2278564721</td>
            <td>rios</td>
            <td><a href="editemployees">Edit Employee</a></td>
          </tr>
        </tbody>
      </Table>
      <Button variant="info" type="submit" href="/addemployees">
        Add Employees
      </Button>

    </div>

  );
}

export default Employees;