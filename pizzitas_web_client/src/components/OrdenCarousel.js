
import Carousel from 'react-bootstrap/Carousel';
import flyer from '../assets/pizzaflyerb.png'


function OrdenCarousel() {
  return (
    <Carousel fade>
      <Carousel.Item>
        <img
          className="d-block w-100 h-10"
          src={flyer}
          alt="Pizza de Peperoni"
        />
      </Carousel.Item>
    </Carousel>
  );
}

export default OrdenCarousel