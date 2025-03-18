
const NewTopicFormStudent = () => {
    const RequiredLabel = ({ children }: { children: string }) => (
        <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
            {children} <span className="text-red-500">*</span>
        </span>
    );

    return (
        <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
            <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
               ĐĂNG KÍ ĐỀ TÀI NGHIÊN CỨU ĐỐI VỚI SINH VIÊN
            </h1>
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    1. Thông tin chung
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-3 gap-4">
                    <div>
                        <RequiredLabel>Tên đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên đề tài nghiên cứu"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        <RequiredLabel>Chủ nhiệm đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Sinh viên chịu trắc nghiệm chính"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mã chủ nhiệm"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tình trạng đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Lĩnh vự nghiên cứu</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 1</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mã sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 2</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mã sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 3</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mã sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 4</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mã sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-4 gap-4">
                    <div>
                        
                        <RequiredLabel>Tên thành viên 5</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mã sinh viên</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mã sinh viên"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
                {/* NGƯỜI HƯỚNG DẪN */}
                <div className="grid pb-5 grid-cols-1 md:grid-cols-5 gap-4">
                    <div>
                        <RequiredLabel>Người hướng dẫn đề tài</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tên người hướng dẫn"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Học vị</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Học vị"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Học hàm</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Học hàm"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngành</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn ngành"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Khoa</RequiredLabel>
                        <input
                            type="text"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Chọn khoa"
                        />
                    </div>
                </div>
            </div>
            {/* THỜI GIAN THỰC HIỆN */}
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    2. Thời gian thực hiện
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Ngày bắt đầu</RequiredLabel>
                        <input
                            type="date"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                    <div>
                        <RequiredLabel>Ngày kết thúc dự kiến</RequiredLabel>
                        <input
                            type="date"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
            </div>
            {/* THỜI GIAN THỰC HIỆN */}
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    3. Kinh phí và tài trợ
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-2 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Tổng kinh phí và tài trợ</RequiredLabel>
                        <input
                            type="money"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Nhập số tiền (VD: 5000000)"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Nguồn tài trợ</RequiredLabel>
                        <input
                            type="date"
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder=""
                        />
                    </div>
                </div>
            </div>
            <div className="pb-4">
                <span className="text-xl font-bold mb-6 text-gray-800 dark:text-white">
                    4. Nội dung nghiên cứu
                </span>
                <div className="grid pb-5 grid-cols-1 md:grid-cols-1 gap-4 pt-2">
                    <div>
                        <RequiredLabel>Giới thiệu tổng quan về đề tài</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Giới thiệu và lý do"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Tính cấp thiết của đề tài</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Tầm quan trọng, tính thời sự hoặc cấp bách,..."
                        />
                    </div>
                    <div>
                        <RequiredLabel>Mục tiêu của đề tài</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mục tiệu đạt được là gì?"
                        />
                    </div>
                    <div>
                        <RequiredLabel>Kết quả, sản phẩm dự kiến</RequiredLabel>
                        <textarea
                            className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
                            placeholder="Mô tả nội dung nghiên cứu, phương pháp thực hiện, kết quả mong đợi..."
                        />
                    </div>
                </div>
            </div>
            <div className="space-y-6">
                {/* Nút hành động */}
                <div className="flex justify-end gap-3 pt-6">
                    <button className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
                    // onClick={onClose}
                    >
                        Hủy
                    </button>
                    <button className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800">
                        Đăng Ký
                    </button>
                </div>
            </div>
        </div>
    );
};

export default NewTopicFormStudent;