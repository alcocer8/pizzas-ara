import OrdenCarousel from './OrdenCarousel';

import React from 'react'

//Orden = card y Ordenes = cards

function Orden({title, imageSource, text}) {
  return (
    <div className='card text-center bg-danger'>
      <img src={imageSource} alt=""/>
        <div className="card-body text-light">
            <h4 className="card-title">{title}</h4>
            <p className="card-text text-light">{text}</p>
            <a href="#!" className="btn btn-outline-info rounded-0">Añadir al carrito</a>
        </div>
    </div>
  )
}

export default Orden