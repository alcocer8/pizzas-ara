import React from 'react'
//import { Link } from 'react-router-dom'
//import logof from '../assets/pizzitaswhite.png'
import logof from '../../assets/pizzitascirculo.png'
import '../css/footer.css'

const Footer =()=> {
  return (
    <div className="main-footer">
    <div className="container">
      <div className="row">
        {/* Column1 */}
        <div className="col">
      <img alt="" src={logof}className='logof'></img>
        </div>
        {/* Column2 */}
        <div className="col">
          <h4>Propietarios</h4>
          <ui className="list-unstyled">
            <li>Eduardo Ruiz Rios</li>
            <li>Roberto Lagunes Alvarez</li>
            <li>Lorenzo Antonio Alcocer Bautista</li>
          </ui>
        </div>
        {/* Column3 */}
        <div className="col">
        <h4>Contacto</h4>
          <ui className="list-unstyled">
            <li>+52 229-000-00-00</li>
            <li>Veracruz, México.</li>
            <li>Universidad Veracruzana</li>
          </ui>
        </div>
      </div>
      <hr />
      <div className="row">
        <p className="col-sm">
          &copy;{new Date().getFullYear()} Pizzitas A.R.A. | Todos los derechos reservados |
          Proyecto Final | PSBW
        </p>
      </div>
    </div>
  </div>
  )
}

export default Footer