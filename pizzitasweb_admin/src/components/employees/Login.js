import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Footer from '../footer/Footer';
import '../css/inicio.css'
import { FormGroup } from 'react-bootstrap';
import Badge from 'react-bootstrap/Badge';


const Login = () => {
  return (
    <div>
      <hr/>
      <h1 className='d-flex justify-content-center'>
        Ingresa empleado de<Badge pill bg="danger">Pizzitas</Badge>
      </h1>
    <div className='d-flex justify-content-center align-items-center'>
      <Form className='rounded p-4 p-sm-3'>
        
        <FormGroup className='mb=-3' controlId='formBasicEmail'>
          <Form.Label>Usuario</Form.Label>
          <Form.Control type='text' placeholder='Ingrese su usuario'/>
        </FormGroup>
        <hr/>
        <Form.Group className='mb-3' controlId='formBasicPassword'>
        <Form.Label>Contraseña</Form.Label>
        <Form.Control type='password' placeholder='Contraseña'/>
        </Form.Group>
      

      <Form.Group className='mb-3' controlId='formBasicCheckbox'>
      <Form.Check type='checkbox' label='Recuerdame'/>
      </Form.Group>
      
      <Button href='/employees' variant='danger' type='submit'>Ingresar</Button>
      <hr/>

      </Form>
    </div>
    <hr/>
    <Footer/>
  </div>
  );
}

export default Login;