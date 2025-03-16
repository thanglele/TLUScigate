import React from "react";

const Link = ({ value, onClick}) => {
  return (
    <>
      <div className="flex justify-between items-center mb-5 mt-2">
        <a
          href="#"
          className={"text-xs md:text-sm text-blue-600 hover:underline ml-auto"}
          onClick={onClick}
        >
          {value}
        </a>
      </div>
    </>
  );
};

export default Link;
