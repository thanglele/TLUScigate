const InputField = ({ label, placeHolder, type, fontLabel, options }) => {
  return (
    <div className="flex flex-col gap-2 mb-3">
      <label className={`block text-gray-700 ${fontLabel}`}>{label}</label>
      {type === "dropdown" ? (
        <select className="mt-1 block w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500">
          {options?.map((option, index) => (
            <option key={index} value={option.value}>
              {option.label}
            </option>
          ))}
        </select>
      ) : (
        <input
          type={type}
          placeholder={placeHolder}
          className="mt-1 block w-full p-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
      )}
    </div>
  );
};

export default InputField;
