import React from "react";
import { Link, NavLink } from "react-router-dom";

const NavBar = ({ user }) => {
  return (
    <nav className="navbar navbar-expand-lg navbar-custom nav-fill w-100" >
      <Link className="navbar-brand navbar-custom" to="/">
        Pepsi
      </Link>
      <div className="navbar navbar-custom " id="navbarNavAltMarkup" >
        <div className="navbar-nav navbar-custom">
          {!user && (
            <NavLink className="navbar-custom nav-item nav-link" to="/login" style={{ color: "green"}}>
              Login
            </NavLink>
          )}
          {user && (
            <React.Fragment>
               <NavLink className="nav-item nav-link navbar-custom" to="/deals">
                Deals
              </NavLink>
              <NavLink className="nav-item nav-link navbar-custom" to="/shoppingCart">
                Shopping Cart
              </NavLink>
              <NavLink className="nav-item nav-link navbar-custom" to="/receipts">
                Receipts
              </NavLink>
              <NavLink className="nav-item nav-link navbar-custom" to="/user-statistics">
                My Statistics
              </NavLink>
              <NavLink className="nav-item nav-link navbar-custom" to="/logout">
                Logout
              </NavLink>
            </React.Fragment>
          )}
        </div>
      </div>
      </nav>
  );
};

export default NavBar;
