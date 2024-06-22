use ApiBanDen
go
CREATE PROCEDURE [dbo].[sp_Den_get_by_id]
    @MaDen INT
AS
BEGIN
    SELECT *
    FROM Den
    WHERE MaDen = @MaDen;
END;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Den_get_by_id](@MaDen      int)
AS
    BEGIN
        SELECT s.*, 
        (
            SELECT sp.*
            FROM ChiTietAnhDen AS sp
            WHERE sp.MaDen = s.MaDen  FOR JSON PATH
        ) AS list_json_chitietanh
        FROM Den AS s
        WHERE  s.MaDen = @MaDen
	END;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Den_get_by_id](@MaDen int)
AS
    BEGIN
		--DECLARE @MaChuyenMuc int;
		--set @MaChuyenMuc = (select MaChuyenMuc from SanPhams where MaSanPham = @MaSanPham);
        SELECT s.*, 
        (
            SELECT top 4 sp.*
            FROM Den AS sp
            WHERE sp.MaLoai = s.MaLoai FOR JSON PATH
        ) AS list_json_denlienquan
        FROM Den AS s
        WHERE  s.MaDen = @MaDen;
    END;
