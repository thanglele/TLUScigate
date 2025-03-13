import React from 'react';

const Link = ({ children, onClick, className }) => {
  return (
    <a
      href="#"
      onClick={(e) => {
        e.preventDefault();
        onClick();
      }}
      className={`text-xs md:text-sm text-blue-600 hover:underline ml-auto ${className}`}
    >
      {children}
    </a>
  );
};

export default Link;