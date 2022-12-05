import OrdenCarousel from './OrdenCarousel';
import React from 'react'
import axios from 'axios';
import Orden from '../components/Orden';
import './css/inicio.css'
import pepe from '../assets/peperoni.png'
import hawai from '../assets/hawai.png'
import queso from '../assets/queso.png'
import Footer from './footer/Footer';

const host = process.env.END_POINT_ORDEN;
const productEndpoint = process.env.END_POINT_ORDEN_ALL;

function componentDidMount () {
  let url = host + productEndpoint;

  axios.get (url, {
      headers: {
          'Content-type': 'application/json; charset=utf-8',
          'Access-Control-Allow-Origin': true,
          'Access-Control-Allow-Credentials': true
      }
  }).then(respose => {
      if(respose.status === 200){
          respose.data.forEach(p => {
            let product = {
              "idProducto" : p.id
            }
            ordenes.push(product)
          });
      }
  })
}

componentDidMount()
const ordenes = [
 {
    id:1,
    title: 'Peperoni',
    image: pepe,
    text: 'Peperoni crujiente con una masa al sarten y un queso Mozzarella de la más alta calidad'
 },
 {
    id:2,
    title: 'Hawaiana',
    image: hawai,
    text: 'Jugosa en cada bocado, piña natural con jamón premium, masa al sarten y crujiente en cada bocado'
 },
 {
    id:3,
    title: 'Cuatro Quesos',
    image: queso,
    text: 'Amarillo, Mozarella, Parmesano & Chedar, juntos hacen una explosión ¿Quieres aún más? '
 }
]

function Ordenes() {
  return (
    <div className='car'>
      <OrdenCarousel/>
    <div className="container d-flex justify-content-center align-items-center h-100">
        <div className="row">
        {
            ordenes.map(orden =>(
                <div className="col-md-4" key={orden.id}>
                    <Orden title={orden.title} imageSource={orden.image} text={orden.text} />
                </div>
            ))
        }
        </div>
    </div>
    <hr/>
    <Footer />
    </div>
  )
}

export default Ordenes

