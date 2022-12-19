
import './css/inicio.css'
import React from 'react';
import Carousel from './Carousel';
import Footer from './footer/Footer';

const Home = () => {
  return (
    <div>
      <Carousel />
      <hr/>
      <Footer/>
  </div> 
  )
}

export default Home