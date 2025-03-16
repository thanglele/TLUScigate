import React from "react";

const WelcomeContent = () => {
  return (
    <div className="text-white md:w-2/5 mb-8 md:mb-2 md:px-2">
      <h1 className="font-extrabold text-4xl md:text-5xl italic leading-tight">
        Welcome to <br /> TLU SciGate.
      </h1>
      <p className="mt-4 text-lg md:text-xl italic">
        Cross this gateway to
        <br />
        explore the infinite sky of science!
      </p>
    </div>
  );
};

export default WelcomeContent;
