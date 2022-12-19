import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Footer from './footer/Footer';
import './css/inicio.css'
import { FormGroup } from 'react-bootstrap';
import Badge from 'react-bootstrap/Badge';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';


const Registro = () => {
  return (
    <div>
      <hr/>
      <h1 className='d-flex justify-content-center'>
        Crear Perfil <Badge pill bg="danger">Pizzitas</Badge>
      </h1>
    <div className='d-flex justify-content-center align-items-center'>
      <Form className='rounded p-4 p-sm-3'>

      
      <Row className="mb-3">
      <Form.Group as={Col} controlId="formGridEmail">
          <Form.Label>Nombre</Form.Label>
          <Form.Control type="name" placeholder="Nombre" />
        </Form.Group>

        <Form.Group as={Col} controlId="formGridEmail">
          <Form.Label>Apellido</Form.Label>
          <Form.Control type="text" placeholder="Apellido" />
        </Form.Group>

      </Row>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="formGridZip">
          <Form.Label>Teléfono</Form.Label>
          <Form.Control placeholder='Télefono'/>
        </Form.Group>
      </Row>

        
        <FormGroup className='mb=-3' controlId='formBasicEmail'>
          <Form.Label>Email</Form.Label>
          <Form.Control type='email' placeholder='Ingrese Email'/>
        </FormGroup>
        <hr/>

        <Form.Group className='mb-3' controlId='formBasicPassword'>
        <Form.Label>Contraseña</Form.Label>
        <Form.Control type='password' placeholder='Contraseña'/>
        </Form.Group>
        <hr/>

        <Row className="mb-3">
            <Form.Group as={Col} controlId="formGridZip">
              <Form.Label>Calle</Form.Label>
              <Form.Control placeholder='Calle' />
            </Form.Group>
          <Form.Group as={Col} controlId="formGridEmail">
              <Form.Label>Colonia</Form.Label>
              <Form.Control type="text" placeholder="Colonia" />
            </Form.Group>
          </Row>

          <Row className="mb-3">
            <Form.Group as={Col} controlId="formGridZip">
              <Form.Label>No. Interior</Form.Label>
              <Form.Control placeholder='34' />
            </Form.Group>
          <Form.Group as={Col} controlId="formGridEmail">
              <Form.Label>No. Exterior</Form.Label>
              <Form.Control type="text" placeholder="45" />
            </Form.Group>
          </Row>

          <Row className="mb-4">
            <Form.Group as={Col} controlId="formGridZip">
              <Form.Label>Código Postal</Form.Label>
              <Form.Control placeholder='94294' />
            </Form.Group>
          <Form.Group as={Col} controlId="formGridEmail">
              <Form.Label>Referencias</Form.Label>
              <Form.Control type="text" placeholder="Lugares Cercanos" />
            </Form.Group>
          </Row>
      

      <Form.Group className='mb-3' controlId='formBasicCheckbox'>
      <Form.Check type='checkbox' label='Me gustaria recibir promociones'/>
      </Form.Group>
      <Button variant='danger' type='submit' href='/Login'>Registrarme</Button>
      </Form>
    </div>
    <hr/>
    <Footer/>
  </div>
  );
}

export default Registro;