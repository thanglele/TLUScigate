
const AddFacultyForm = () => {
  const RequiredLabel = ({ children }: { children: string }) => (
    <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
      {children} <span className="text-red-500">*</span>
    </span>
  );

  return (
    <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
      <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
        THÊM GIẢNG VIÊN
      </h1>

      {/* Section 1 - Thông tin giảng viên */}
      <div className="space-y-6">
        <div className="border-b pb-4">
          <h2 className="text-xl font-semibold mb-4 text-gray-700 dark:text-gray-300">
            Thông tin giảng viên
          </h2>

          <div className="space-y-4">
            <div>
              <RequiredLabel>Họ và tên</RequiredLabel>
              <input
                type="text"
                className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                placeholder="Nhập họ và tên giảng viên"
              />
            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <RequiredLabel>Email</RequiredLabel>
                <input
                  type="email"
                  className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                  placeholder="Nhập email"
                />
              </div>
              <div>
                <RequiredLabel>Số điện thoại</RequiredLabel>
                <input
                  type="tel"
                  className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                  placeholder="Nhập số điện thoại"
                />
              </div>
            </div>

            {/* ... Các phần khác tương tự ... */}
          </div>
        </div>

        {/* Section 2 - Giới tính & Trạng thái */}
        <div className="border-b pb-4">
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <div>
              <RequiredLabel>Giới tính</RequiredLabel>
              <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                <option>Chọn giới tính</option>
                <option>Nam</option>
                <option>Nữ</option>
              </select>
            </div>

            <div>
              <label className="text-sm font-medium text-gray-700 dark:text-gray-200">
                Trạng thái
              </label>
              <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                <option>Chọn trạng thái</option>
                <option>Đang làm việc</option>
                <option>Nghỉ việc</option>
              </select>
            </div>

            <div>
              <RequiredLabel>Học vị</RequiredLabel>
              <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                <option>Chọn học vị</option>
                <option>Thạc sĩ</option>
                <option>Tiến sĩ</option>
              </select>
            </div>
          </div>
        </div>

        {/* Nút hành động */}
        <div className="flex justify-end gap-3 pt-6">
          <button className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200">
            Hủy
          </button>
          <button className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800">
            Thêm
          </button>
        </div>
      </div>
    </div>
  );
};

export default AddFacultyForm;