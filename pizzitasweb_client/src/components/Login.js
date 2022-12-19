import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Footer from './footer/Footer';
import './css/inicio.css'
import { FormGroup } from 'react-bootstrap';

const Login = () => {
  return (
    <div className='color-overlay d-flex justify-content-center align-items-center'>
      <Form className='rounded p-4 p-sm-3'>
        
        <FormGroup className='mb=-3' controlId='formBasicEmail'>
          <Form.Label>Email</Form.Label>
          <Form.Control type='email' placeholder='Ingrese Email'/>
          <Form.Text className='text-muted'>
            No le dire a nadie que estuviste aqui.
          </Form.Text>
        </FormGroup>

        <Form.Group className='mb-3' controlId='formBasicPassword'>
        <Form.Label>Contraseña</Form.Label>
        <Form.Control type='password' placeholder='Contraseña'/>
        </Form.Group>
      

      <Form.Group className='mb-3' controlId='formBasicCheckbox'>
      <Form.Check type='checkbox' label='Recuerdame'/>
      </Form.Group>
      <Button variant='danger' type='submit'>Ingresar</Button>
      </Form>
    </div>
  );
}

export default Login;