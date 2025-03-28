import { useNavigate } from "react-router";

const AddScience = () => {
    const navigate = useNavigate();

    const RequiredLabel = ({ children }: { children: string }) => (
        <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
            {children} <span className="text-red-500">*</span>
        </span>
    );

    return (
        <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
            <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
                Cập nhật bài công bố khoa học
            </h1>
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    1. Thông tin bài công bố
                </span>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                    <div>
                        <RequiredLabel>Mã công bố</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tiêu đề</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
                <div className="grid grid-cols-1 md:grid-cols-1 gap-4">
                    <div>
                        <RequiredLabel>Tóm tắt</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
                <div className="grid grid-cols-1 md:grid-cols-1 gap-4">
                    <div>
                        <RequiredLabel>Từ khóa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Ngôn Ngữ</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Loại công bố</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Tạp chí trong nước</option>
                            <option>Tạp chí quốc tế</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>ISSN_ISBN Mã công bố:</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Chỉ mục khoa học</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Tạp chí trong nước</option>
                            <option>Tạp chí quốc tế</option>
                        </select>
                    </div>

                </div>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Impact Factor</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>DOI</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Năm công bố</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>

                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Số trang</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>File đính kèm</RequiredLabel>
                        <input
                            type="file"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
            </div>

            {/* THONG TIN TAC GIA */}
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    2. Thông tin tác giả
                </span>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Tác giả</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Email</RequiredLabel>
                        <input
                            type="email"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
                <div className="grid grid-cols-1 md:grid-cols-3 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Học hàm</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>PGS</option>
                            <option>Giáo Sư</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>Học hàm</RequiredLabel>
                        <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
                            <option>Tiến sĩ</option>
                            <option>Thạc sĩ</option>
                        </select>
                    </div>
                    <div>
                        <RequiredLabel>Chức vị</RequiredLabel>
                        <input
                            type="email"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
            </div>
            <div className="space-y-6">
                {/* Nút hành động */}
                <div className="flex justify-end gap-3 pt-6">
                    <button className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
                    onClick={() => navigate('/science-tables')}
                    >
                        Hủy
                    </button>
                    <button className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800">
                        Cập nhật
                    </button>
                </div>
            </div>
        </div>
    );
};

export default AddScience;