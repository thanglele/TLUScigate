import React from 'react';

const Button = ({ children, onClick, type = 'button', className }) => {
  return (
    <button
      type={type}
      onClick={onClick}
      className={`w-full p-2 rounded-md transition duration-200 font-bold text-sm ${className}`}
    >
      {children}
    </button>
  );
};

export default Button;