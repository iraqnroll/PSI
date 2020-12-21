import React from "react";
import { Link, NavLink } from "react-router-dom";

const NavBar = ({ user }) => {
  return (
    <nav className="navbar navbar-expand-lg navbar-custom">
      <Link className="navbar-brand navbar-custom" to="/">
        Pepsi
      </Link>
      <div className="collapse navbar-collapse navbar-custom" id="navbarNavAltMarkup">
        <div className="navbar-nav navbar-custom">
          {!user && (
            <React.Fragment>
              <NavLink className="nav-item nav-link navbar-custom" to="/login">
                Login
              </NavLink>
              <NavLink className="nav-item nav-link navbar-custom" to="/register">
                Register
              </NavLink>
            </React.Fragment>
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
              <NavLink className="nav-item nav-link navbar-custom" to="/item-history">
                Price History
              </NavLink>
              <NavLink className="nav-item nav-link navbar-custom" to="/logout">
                              Logout
              </NavLink>
                <NavLink className="nav-item nav-link navbar-custom" to="/change">
                    Edit Account
                </NavLink>
            </React.Fragment>
          )}
        </div>
      </div>
       
    </nav>
  );
};

export default NavBar;
