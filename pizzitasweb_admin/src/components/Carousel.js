import Button from 'react-bootstrap/Button';
import Carousel from 'react-bootstrap/Carousel';
import p1 from '../assets/paneladmin.png'


function CarouselFadeExample() {
  return (
    <Carousel fade>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={p1}
          alt="Pizza de Peperoni"
        />
        <Carousel.Caption>
        <Button href='/employeesmanagement' variant="danger">Iniciar Sesion</Button>{' '}
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default CarouselFadeExample