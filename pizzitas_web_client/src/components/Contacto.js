import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';

function Contacto() {
  return (
    <div>
    <div className='color-overlay d-flex justify-content-center align-items-center'>
      
    <Form className='rounded p-4 p-sm-3'>

      <Row className="mb-3">
      <Form.Group as={Col} controlId="formGridEmail">
          <Form.Label>Nombre</Form.Label>
          <Form.Control type="name" placeholder="Nombre(s)" />
        </Form.Group>

        <Form.Group as={Col} controlId="formGridEmail">
          <Form.Label>Email</Form.Label>
          <Form.Control type="email" placeholder="Ingresa email" />
        </Form.Group>

      </Row>

      <Form.Group className="mb-3" controlId="formGridAddress1">
        <Form.Label>Mensaje</Form.Label>
        <Form.Control placeholder="Requiero de..." />
      </Form.Group>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="formGridZip">
          <Form.Label>Telefono</Form.Label>
          <Form.Control placeholder='229-000-00-00'/>
        </Form.Group>
      </Row>

      <Form.Group className="mb-3" id="formGridCheckbox">
        <Form.Check type="checkbox" label="No soy un bot" />
      </Form.Group>

      <Button variant="danger" type="submit">
        Enviar
      </Button>
    </Form>
    </div>
  </div>
    
  );
}

export default Contacto;