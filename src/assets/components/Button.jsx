import React from "react";

const Button = ({ value, color, onClick, textSize}) => {

  return (
    <button
    className={`w-full p-2 rounded-md transition duration-200 font-bold text-sm ${color} text-white hover:bg-blue-700 mt-3`}
    onClick={onClick}
    >
      <p className={`${textSize}`}>{value}</p>
    </button>
  );
};

export default Button;
