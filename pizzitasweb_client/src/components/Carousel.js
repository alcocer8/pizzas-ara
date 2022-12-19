import Button from 'react-bootstrap/Button';
import Carousel from 'react-bootstrap/Carousel';
import p1 from '../assets/PizzaPeperoni.png'
import p2 from '../assets/PizzaHawaina.png'
import p3 from '../assets/PizzaQueso.png'

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
        <Button variant="danger">Ordenar ¡Ahora!</Button>{' '}
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={p2}
          alt="Pizza Hawaiana"
        />
        <Carousel.Caption>
        <Button variant="danger">Ordenar ¡Ahora!</Button>{' '}
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={p3}
          alt="Pizza 4 Quesos"
        />

        <Carousel.Caption>
        <Button variant="danger">Ordenar ¡Ahora!</Button>{' '}
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default CarouselFadeExample