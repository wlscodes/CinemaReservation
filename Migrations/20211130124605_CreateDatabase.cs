using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaReservation.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HallID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HallID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Row = table.Column<short>(type: "smallint", nullable: false),
                    Column = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seats_Halls_HallID",
                        column: x => x.HallID,
                        principalTable: "Halls",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BougthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seats",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), "Sala 1" });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), "Sala 2" });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("86a6eec6-a093-4b77-a90f-71b86ffae650"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("943eca0f-b0f3-4db8-a73d-30627faace0e"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("b08a4195-00d6-4c74-9d61-28e2f7f0cd2d"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("4d7ed3dc-563d-4d50-b151-b73c279e8738"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("452c3bce-fd90-420a-af37-6e24701ebe59"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("cd6ce0d9-2e9d-486b-b8ca-5e0476cf5a53"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("b805a544-9b74-4e5c-a3f5-ebbcc1ac1edc"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("e1b5f89a-78ca-46d3-8308-75d690468731"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("2c0adc4c-b82b-4f5e-b74f-9cc7e87c67b0"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("5db6e01e-f631-4f87-af99-fa3c6d907ecc"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("434604ca-72dc-4300-90b2-3fd4525119ca"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("f93aec08-566f-4460-bba7-ebb7cebe577a"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("bd05a95a-2e9f-4f4c-b7df-35e8de103e13"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("5d866652-64bc-4b84-bb45-290f4d61258e"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("5a1638e8-45e5-40ef-8b49-d6b79617b76c"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("73ea9680-d223-4029-b536-ffd35ec8fb88"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("999b9308-3532-406d-ae74-a776fb2d4349"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("ec7e49c3-25f5-4077-b701-cd7caf14a5d3"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("7f1fca3d-2457-46a9-9b9f-b760b082f2fe"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("a293de37-8b8d-4d6e-b409-f81f920f1f27"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("2d6436a4-d12c-4b18-ae62-322e95ab6cf3"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("6a77ab96-70ff-411f-845f-d3c039c70bef"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("e4014758-3fa7-4e1f-971f-00366b4ccaac"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("c5ef2683-5681-4032-8d4f-4c758363f766"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("044a4132-f53d-4948-889f-e2139ffc7fa9"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("9f8be4a5-61d8-41af-a34f-832e681d80e6"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)4 },
                    { new Guid("65ecbcb3-f496-4154-9e6b-9859851b066f"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("481e1b7a-5f7a-47b4-8fc9-ce29fdbac2a6"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("3a638653-86d3-487a-80c3-6c4b2b56e1d9"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("19834f7c-13f4-44a0-8d55-204965b7096c"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("89a43cd0-130c-4d16-8add-de7430ec30f8"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("d06b4829-b1b2-43ff-8b86-875feca117be"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("7b927329-b4a2-4896-8e55-f11b776a9a4b"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("6f90aef5-eda9-486c-9901-45f8a324418d"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("b51bdd78-07b1-42bf-b1a6-2d0038fff325"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("8ec81f65-d959-429b-9b8e-5e176dce7ada"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("cd22d80d-5be9-47a1-bb0f-74fe95ef088b"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("d5ec6c4d-472d-4137-990d-6cda4d92e512"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("a9be2578-ca58-4843-9fa5-50a0af5dacbf"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("e19045a4-3470-48bc-ab53-a461620cd237"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("eeb3c0f0-19b6-4f55-9fc5-261b2456a25f"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("bb069a4a-c21a-4b0f-8ac5-3c8c5e2e7a6f"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("20edaa69-b814-408f-a0c1-c43905fef6f4"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("322ebff5-b349-444d-b7f2-5254351c80bc"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("73e489d0-19a1-4ca1-8f9d-a48385868b95"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("e37b672d-1565-40a5-8c26-7b2d32b1ea9c"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("bf23d61a-56c8-4cfe-97b8-87d7f8aaaa51"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("b0c4fa40-29d3-4043-83b7-c5a9a9201583"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("98ca0054-d370-4619-931b-5c3b484ba1db"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("ee46464e-ed0d-4b4a-b807-c1117e06438b"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("d8183412-b49b-4b3f-92ce-d25e255804d4"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("fdf20dc0-4888-4927-b7bb-dda163405580"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("d70c9c0c-58db-4953-9fa5-72857559af83"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)5 },
                    { new Guid("027618f5-b5a6-466e-a322-bd3d38d8d75f"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)6 },
                    { new Guid("e7841b0c-294f-4fd3-bda7-19ef56b429d6"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("3a9cbd2b-9e88-499e-b7ce-f833538e98cb"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("892fd7a3-d419-4339-b0a4-1fec850aa7f9"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("687d8efa-087b-4752-a78f-92a0712568df"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("ae391629-abe6-4cb3-9727-1f2aca1dac07"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("6abde273-d14a-4a52-9ed0-9fea4fbffccf"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("bab3a165-a316-49f7-9776-7ab7fe851f6f"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("da8497cb-491d-4564-bdb3-43b1897c391d"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("e3ebcc33-46d5-4017-987a-7f87ac9a2f40"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("61601683-9d40-420a-a59b-fd12fa44faaf"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("eef20009-0396-4323-8c42-02e9b76a0a01"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("be407a47-ecd1-4489-b3ac-9b2442dbec9b"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("f5e1a667-161a-4f5a-9a9c-804cfc429f2c"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("210de09b-673d-482d-ac54-11722f8c2879"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("5b2e77b2-9ac9-47e6-baf3-d763414479b4"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("1ee0645d-94bb-4802-992a-8900b347722e"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("ff0ef1e1-6bd0-4a79-9fd1-19c5b725f19b"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("528eecdf-cdc6-4292-9614-8293aaa99b16"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("fea72145-c88f-4a17-bc8e-639bcc883231"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("7f055a6f-c576-42a5-8d9f-e7fc97acad95"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("da33edd2-8338-4caa-a105-16d8396ae9bb"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("36d783a2-303a-48b1-9b28-aa7093ffddd3"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("59239ce4-0795-4a2b-9799-21b9b4c24641"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("b705112d-a5b9-4283-9fe9-5dd4b514a40f"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("3ced6b2e-b2da-4855-9605-8187ef1c08f7"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("61d024d7-e164-44b4-80b0-45cc77c5d08d"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("29eb2298-3493-47ce-b647-9fac8af11557"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("fff2df68-f790-48e4-b3d5-200701a8d57a"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("2aa61779-cecc-4486-ac57-d6d8c3ab0fa1"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("82d493f9-565e-4d43-8436-c8f150de4fb5"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("2223de41-37b8-4d5f-bc80-ca81e2cc4d8f"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("507be397-4718-48c5-b13c-1e9163c42488"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("0cbac885-5973-4368-bafd-079025378365"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("388426f1-1ea0-459e-a303-91ef132008e4"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("6315e450-4e55-42c1-bc3f-c6be66d31353"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("158b23f0-fd91-4462-a835-b795f17ddbe4"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("0c3159a9-fe63-4655-805d-a20723a3dde7"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("b2231943-55ed-4aeb-bee5-d8712b53806d"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("4ce12644-c667-45c0-8106-c6f1087f0ef5"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("8cbf930f-3e9c-4e33-a954-e35bf98573fd"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)3 },
                    { new Guid("b76c6548-865f-4cbc-8b53-acf0bf886694"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("b5214f60-f61f-49fd-88de-cbba4642fdf5"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("a3208065-b7f1-4c70-a91c-aca3a77465c7"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)1 },
                    { new Guid("c817ab85-2d93-4198-a929-4883f9925c66"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("0f0e6a85-1720-4dd9-988b-79fe0b3be56e"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("0f0050b9-b138-4e2b-a14d-976fa4382f00"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("31fa68c3-bbcb-46f8-8a32-9ca7d9f376e1"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("acba2888-73dc-42d7-8103-8c261206fc42"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("2725e47d-a699-4a4a-92ab-4ee8a8b4ca29"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("6659c769-793f-40dc-9a7a-8ebf13d0de15"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("27368fe8-7444-4851-8f9f-011e67ed1cf3"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("2ba483ff-2dbc-4294-b262-e87cbe55aeb5"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("e8f4425b-7279-4aab-a87f-9ff360031035"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("89f78875-5614-4d49-ab3a-d51e09f14ea2"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("af9a4359-8e03-402f-b921-7d3f5e14c068"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("8c3401c7-c4e1-4a2f-9c90-3a808c4ac851"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)2 },
                    { new Guid("21cf6a90-e808-469e-9f35-e11e0d2348ca"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("33440b11-0a42-45b7-aac3-9f84ef3d1d1e"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("d9672730-514e-49b3-8efa-21c5f6aa07c3"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("6674a7f7-eef7-41f4-bec7-df4d9c9f07cc"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("0b1743f3-577a-48a9-9831-e6ed47277e4c"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("c76febc1-d854-42f2-b770-ba01a1dd2e1d"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("7edd57b9-e0e3-486f-bfb5-baec613e45f9"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("b9b4e53f-0e7b-4071-9343-b4a852357c81"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("59e87b63-fe91-4b9f-a661-f5dde237cdfa"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("4b697062-9126-4b1a-b8e1-0123739226c3"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("e26ae7c1-89f2-4e7d-9bd8-621763e2cb9b"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("14444970-3109-4942-81ab-d886628df524"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("f16e9120-8282-41ac-bc03-bd96c9c9e274"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("745260ad-62b0-4169-b97a-acd40ea52b11"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("f57770fe-bdb9-4a8e-a536-1510d4387423"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("761f9aa2-9ac0-4c4b-b135-996add3b9bb4"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("afd9c2aa-d31e-475a-bc30-64ab7a6778b3"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("5a7b20a8-c600-40e0-9829-081671397fe0"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("af5e4859-fcfe-4364-8704-9c128fa698e7"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("4fa29cf2-3b2d-4fbc-92b4-a8f5bf6ecc11"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("cb8a2601-d292-45fe-88ad-3b13ff725743"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("5e99ca15-28fb-4c7f-a197-1e9cf733de9c"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("d817c027-ff46-4083-9a84-ddab73a8c6da"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("110800f7-2502-4d09-94ed-8f90d20e58df"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("d519d24b-6816-4464-a5da-859f5d5a76e7"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("38ae8fec-9825-41bd-bdef-db50e26fa5d6"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("e09d9b19-fe41-43d4-8c34-17d6bfcc3fc5"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("0f5498cf-281d-44b4-9732-b3867bd76dcc"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)12 },
                    { new Guid("89ed3aa2-9390-4d96-a90e-640f24ee8819"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("ffe492e8-b9ca-499d-9787-d0fc8982b9c6"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("aa330d90-6a32-477d-a27a-fda424217bf3"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("616fa4bf-15c1-401d-8498-9b3d571f128f"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("20ef3b4d-8f93-4f88-8ff2-15a56adc13e6"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("7416e173-2f64-49ab-af8e-5c060ef0e7d3"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("8df98f80-a7d1-4b1b-928c-5f5f8b2de2da"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("8ea7b879-c343-446d-9f8f-0c935200814d"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("b40d5355-634f-4660-bcd8-7c3a31effba3"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("b17fbb85-8e02-42d7-a606-ed10df9cfcb1"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("21a8724d-125f-45da-aa63-c4ee02d43c14"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("26fe8480-ff3e-4a58-a426-3c1b55bccb5a"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("f0d30c82-1c0f-4680-87a1-cacbc3127907"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("3b555939-7ab5-4d6c-99d3-36ad3234857f"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("c72943d1-99b1-4040-adb1-5f51a4faa7b9"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("b94413be-b4f6-40b5-ac03-f6a6a29bdf7c"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("9dc2f5f1-c62a-4848-ae49-3f2ca99d164a"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("474db6d7-b9a9-4beb-884f-e367fd0480d8"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("5ce19297-c894-4f5f-9490-8bc29f76a2aa"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("ae62a528-f52e-4b1c-b46c-1549aca4c146"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("bd08e113-2111-45aa-a22e-2c9803774f05"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("438270eb-fc93-4f95-862d-ae00ec9af9a5"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("626e632d-5286-489b-878e-3fb99aefd741"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("3fbd5076-5643-4468-8bf3-ba50cd7e2036"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("8403a5a8-3336-4f84-af00-a0a27c71c934"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("ace9d994-5cf9-4e84-b59a-f53014e4cf68"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("828aa6c3-c995-43f6-8e91-9d46b30081c1"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)13 },
                    { new Guid("039a4b6a-58bf-4c0e-b262-e2d57a6886cf"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("f962c42a-d3ab-47f6-a6ea-1b79a3ba3711"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("e10e3e9d-3ddc-4797-9981-789eb91f16f8"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("f126d5c6-6d7a-4f60-b8d2-2d25051be472"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("bf407d10-ee0c-4cd4-95eb-cda8020e355f"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("d41026df-ec21-4424-8d66-01517f2593a6"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("73fbac5c-23b2-4d97-9938-bfe5ed10b145"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("f437b07b-b519-4bcf-be23-b53d818addcc"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("4f007674-2680-48ac-b0db-61e298002265"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("ac1c0f6e-f3b1-4ae7-b48a-d7f87a241eac"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("8cc55f2e-96b1-40d4-beb0-8c7c231c0fa1"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("fee0c9ba-1be0-42bb-b216-dbd4b6bf127b"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("4d3df71a-0857-4c02-a03c-6113a04fbd32"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("5cd75a23-3011-48c8-9f87-7991b083daa1"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("25dc0275-c109-4e14-aed3-dd0073098811"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("f97d87b2-b9ef-4d2b-bf14-5fc6ef11a0a6"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("d58bef48-edda-49a8-8910-ce5ac4f623a1"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("7e2519e4-e9ab-49ab-9508-e78dff0fc7fd"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("ae6449d1-a8be-4d56-8000-2d3c22e94746"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("426d7a21-8b80-40fb-a29f-ba7e97a90186"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("72d03ccd-5d63-4494-a939-44b0b2302602"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("32c8726b-32f5-4e56-9f6a-7aec760cfd4b"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("d576b9a5-8351-45af-9eb3-57adc657cab8"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("e728e542-31fc-44e8-ab95-dfcb21f105f9"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("599d2a10-e6f4-490b-98b0-b15c99e79557"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("a30ac5f8-dbe1-4f69-8066-545943800907"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("5c5b9a92-d59d-4425-af1a-a5b4dd90690f"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("06c1a437-7434-4752-809b-a1df3485a38e"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)7 },
                    { new Guid("eebb0aa5-f386-481d-bcb7-c079058446d9"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)8 },
                    { new Guid("99925325-ef9b-4502-99a0-cccf846e82fb"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("67cbdf03-7d01-46b0-a79a-a04ba95edd44"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("38f9a9d7-6357-4001-9e0d-096a6a1ed6ff"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("783b3229-d19d-4078-91d2-76dc4bed0d90"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("ba06c3e2-7689-492d-a261-70db59a496a7"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)11 },
                    { new Guid("421f73f8-552f-4556-b0f0-e646209c5836"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("c6e22bd9-ee07-4b59-bbae-b2debe96e2bb"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("5b062fc1-fcbc-466b-9e71-13fc55539726"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("72682884-f507-4888-8941-905192a968c7"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("0c4bd15e-0437-4b66-9c7c-747399d7b765"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("76ab6896-7b47-470c-8774-97e2ffc83e66"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("9d753025-38a2-46f9-a6b9-e0d5e289c0f7"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("c5f87a47-7eff-41c2-9aeb-652dcd591c89"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("2003d830-480a-48a3-8f5a-7e312fe8e517"), (short)6, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("563ab57e-56ac-4f1f-bbbb-4bc42ee05f16"), (short)5, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("df5c2674-c91a-4315-b9ee-653a6c056e7f"), (short)4, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("8ecb5575-c1f6-431c-9a37-82017a0579ad"), (short)3, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("4c1691de-3054-476d-ba33-3ab1a9fe8ed8"), (short)2, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("52f283ef-cf57-4364-a2bc-1f2da8db2c63"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("80dd6e26-21bc-4190-9182-acff4d745727"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)10 },
                    { new Guid("69a2594a-5491-462e-9eea-d3508f4634df"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("d02eac36-38d1-44a7-8484-9d138d8d95a9"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("fcfd2ce1-6db9-4eaa-aa81-5bb1f8f81871"), (short)12, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("d04ad270-b675-4a6e-831b-c9eedc300718"), (short)11, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("1d5b8a07-cc91-4c9b-befa-3d84ea0b67d0"), (short)10, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("8586dd9b-fc9e-4b6d-b3fb-8074b50d6c4d"), (short)9, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("a3ac693a-d1ec-40aa-993e-5812c7ab469e"), (short)8, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("d303f396-f28c-4e93-adb8-3c0102642980"), (short)7, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)9 },
                    { new Guid("2cb3f20f-55c5-47c4-b303-d1fba9849668"), (short)1, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("0cc67d08-fb39-4250-a972-1fbcbb21216f"), (short)0, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)0 },
                    { new Guid("51a80315-9870-4d3a-9ef9-67db8152531d"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("791cc322-0f8e-4679-b736-05e4e8bfe448"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("8eef3e86-19be-4662-b2f3-6735b160c7af"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("76166762-dee3-4c83-ac13-7932b0bd2d7e"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("9ce2b1e9-ef4b-4bc2-909d-338b7e89dcb9"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("64e6b11b-be84-4017-a314-03ad9ca6001f"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("fa629f1d-8221-4d25-b302-45d6a2668e81"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("b64974b9-595c-4831-9624-f5c018ba5bae"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("6f95cc9c-70bf-4fe9-a6b8-76fbc364c76e"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("f63a5788-bb8c-4707-b9c6-6910462f0e93"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("0fdba014-fab1-4895-8512-8c6d8ec29118"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("76950226-61d4-4efc-ba92-aeeedcd1cdaa"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("9148c168-af0e-41e3-944d-d2c2b078f2f9"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("443ee9c4-af1b-4137-8ed2-9d83267475ae"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("025fe51b-84b1-44d3-8cd6-e4c0499c20b4"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("6d11b228-37b7-4b38-8da5-94f8ecb0729c"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("81d07542-516c-41b5-ada2-aebd90f803cb"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("d706495e-5c52-4a43-a32e-e8ae98c37774"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("40f44ddc-a60e-4ed2-92c0-4e301de8efeb"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("7057388f-4e86-492a-9807-c8b2366e5a64"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("7ecb614c-b532-413f-9890-28d98daa9254"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("4eb3b181-8687-44cf-a0e0-67bc1568a8ba"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("dce47bce-6624-4e75-a951-bb152ed9f530"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("b7e46b68-6b74-4ae6-b1c3-afa5d1d32084"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("58423bbe-fa1b-4edf-9153-bbcf9d3f90c0"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("4230eaea-bbbd-4806-8ca7-9c055a67d0a5"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("495e053c-875d-43ae-b57d-ab0c32594ea9"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)4 },
                    { new Guid("c6bb2a36-bb7a-4642-9c9e-55cb323d80b7"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("00d98d9a-9add-4ade-9d6f-fdf2c52d2b51"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("5597832c-aae5-47aa-ba67-6e3662c2d64c"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("4cd3d4e5-73f4-469a-8a18-64829dce0450"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("82126fb4-99a4-4f45-a15f-551a882b1e19"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("d6658e24-b6bd-4c3b-aa93-a0aec437dd26"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("71108b57-9c91-43db-8383-83c4a20c1c72"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("1acef655-5b6f-448c-b59a-1a939c24a121"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("667d9a51-7744-44af-8121-122d00791cbb"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("7f6436ec-3675-4445-a57b-475a405d595d"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("526ffef7-3d41-465e-903c-a2a2a36c73e8"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("4e0c0537-bf14-46a2-8682-23c0ddcc87c1"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("b90a8127-65e0-483a-b44b-fbb84652b7b9"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("b6447657-7b5f-41f2-8240-7c8e4cbaa24f"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("05a8b5ad-f4e7-4800-abaf-0aa68003a9e4"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("6c1fd707-6816-4ec8-8977-132f077d4fa7"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("aa2dd523-cd22-449a-bd45-2660a49757ba"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("43a5e5f9-aefc-4cf7-a557-71eea9e7d84d"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("cc35780e-27f7-43f3-95ab-7147032d96dc"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("9b3e0309-14b5-466c-8c2c-b8b7e4fe1f05"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("edf649bc-b4ef-4479-b445-feff88e038ba"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("aeb872f4-faac-4186-aa8d-f12c28457c1b"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("07be00ee-4973-40d8-b27c-97bdd8eb77fe"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("15211f7a-0bfe-414f-8e7f-69cf8ca77ff1"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("5c414215-10fe-4d43-83a8-825bf1f2bf19"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("198b5de3-96ae-4e7a-95e9-e22520c3a297"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("d09f9688-3341-412e-b4db-db664701d63b"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)5 },
                    { new Guid("5e51b289-3418-4cee-8015-c8d0b8c8ad2b"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)6 },
                    { new Guid("3c7336fc-5b1a-4dd6-a537-a36243d760e6"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("7afcb91b-f7cf-4cdf-8300-364a1160d8a4"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("a44e166f-dc45-44a2-97d8-59c4aadb782f"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("0a74cac8-92ce-4cc5-a346-b556362f73f0"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("55ea6458-5596-4d96-9d40-5e4fb3949c3a"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("cc42391f-158f-4965-9d27-ddb175818a12"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("3b34574e-26a8-445b-9f68-147a0bdec5f3"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("e857b930-d044-4ab8-8a4e-5ab63819d5b0"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("2c754e58-8325-4edf-8149-82a25f364b33"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("8d1efae0-0323-46f7-8cf2-bd4c2e7dcaf5"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("643b1db9-e359-416f-af90-b8d1138ab3ad"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("dffe329b-5ebc-4a69-9769-c2adbb98c983"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("891e078b-4d7b-4ce2-be7c-38038b4d785b"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("190a5361-c476-4248-9cda-e360b48d693d"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("1e305c40-a392-45b6-bf99-aa13d353ed00"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("9952bc5c-0f22-4be1-8057-8fa5f37e800f"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("5f6858e0-241e-4b58-815a-f57ce83205fc"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("c29519e5-91ab-411d-b8fa-d96c45545eb4"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("10e87d7e-1256-48b3-8500-4b7efd4caa29"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("2c081569-c1f1-460e-a5bc-e9e0026aa055"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("bc5fc9f9-98eb-498b-9a81-3a2b6044b521"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("5bf7a769-cdd0-4265-b7fe-58fb68559697"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("38744c73-cc5c-445a-bb0b-361f031e4f2c"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("a5b4bd26-a734-4a7f-a3b7-84753c456e05"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("45277f2b-4b93-4753-ac75-df0de96fa8e4"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("534657e3-77fd-4b74-aa17-f1b5731ac504"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("6f912b2a-abce-4ea4-86d9-640d863de0e5"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("49a3a336-cfb8-4697-9c74-053633b9c144"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)0 },
                    { new Guid("bd999a90-12b8-4f70-bc6d-dc12b644c754"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("b6e86c1f-627b-45cb-b261-dd34c39710f3"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("3a5e9da2-b394-42e8-9da7-5409aabb0520"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("800bfede-a077-41bb-b921-9e2fc811396d"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("1f14ac6d-f2de-4a31-9947-aa82f2223a2a"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("67f2c88a-1ac4-4192-98b1-b6375608b06b"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("d462b8c2-6ebc-4556-9327-d510fcaa6199"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("3bc624f2-b7ff-4b9b-b707-febc32fd347a"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("f6df6286-a7a6-4d44-9491-d4e8b287ccfc"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("ef11aaf9-0c9d-4dff-9073-723999567bc4"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("51f1325f-3c49-4ed2-ba03-e2978e67f73b"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("68ad5375-d147-4cbd-9eba-85eced6217c0"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)3 },
                    { new Guid("cb44b7ed-07a5-4bd7-a2e6-66950d33b00d"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("237bebc3-47c5-43cd-975d-ffe699d89490"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("c9ee2ad8-6336-4d88-a8bb-7f3741fe2b82"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("cabb314f-d5df-47db-bed1-64fa4eb32654"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("e53f5afa-6a31-4092-bf83-c9fb85518b45"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("f6d31e8b-f7bf-4509-9fc3-e91e1320b288"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("e8940554-2b43-4007-82fe-4934ee3ee936"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("3b0c9af2-c068-4263-99d2-8f1a684c7fc8"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("868b8572-f2a4-46ae-8bf8-861088831860"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("b00a0b26-48a9-4438-b403-f25ac392deb3"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("94d6e72e-c2a7-4ffd-ac6d-2d13f25d56a2"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("2d71a220-425d-4a63-b16d-a283d96294be"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("82a3e524-a272-489c-bfd1-1b8e56453532"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("4a40ab89-ac11-437c-aefa-ede8f85172c0"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("7fdf7cef-37e4-40bd-a1f0-b41158b79c85"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)2 },
                    { new Guid("ed64a92d-8a08-4be5-b41c-181e75b4f12a"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)1 },
                    { new Guid("3ee03cb4-c52f-41c6-9c65-261a2fd2015a"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("103c811f-f8c2-4166-9986-0fddc7811d2f"), (short)13, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 },
                    { new Guid("b243fddd-5a92-4b07-9886-3222e5418bc4"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("47c1d3a1-1c48-4aff-9ae9-54a37f4ff27b"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("3909449e-e985-4f2a-8f76-493771859a55"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("7403f624-f54d-4ad9-bf03-144de92d5dd6"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("5f0766ed-9e4d-413a-92e2-2d874c28a0c0"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("900f0407-8d11-4b10-be09-dcf08d83d44b"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("15ecff70-ed0f-416e-907f-df576c1c620e"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("50a79b3b-891c-43c6-b936-e5d05eb850f0"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("20a85656-fec4-4a55-92da-6ede120137fa"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("74169720-5233-41dd-bc22-0bfb2206f5d2"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("cb00122a-4e8c-437d-9973-bcb812a75c36"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("c06e4e90-2789-4a5f-a26c-9df9ff967ab0"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("98bd4936-3ae0-4419-a425-c55ed7ee169f"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("c40cf882-06c9-4cff-93b8-2e320b2b55df"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("f81629c0-e71e-4cd6-820e-ef896cbe9558"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("e64891cf-f031-4580-b635-0418804e304f"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("cc868dc0-61f0-4534-9fed-798d52ea16d7"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("fe1b60de-2cf5-4fa6-bcce-998b5a6dfaf0"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("572f6df0-4af5-4b8a-b185-04d0e9f97ff6"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("34ed5a72-2818-4551-bf19-7c02b2391083"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("40e4a957-eb16-4d78-b803-d6db2051c1c0"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("61750590-1715-4ded-a47d-b209f9fbc181"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("1cdc9f50-f95e-4d5f-beda-6c5902bd75b2"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("aa220fe6-1719-40e2-8187-8443ee67b893"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("aa9aeac3-d9d1-4277-a661-0e7e766d82e6"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("ed304968-49c0-441e-8cb8-718496427fbb"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("61a83226-eef1-4a25-8d3e-2f748940d60e"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)12 },
                    { new Guid("898c873d-8595-4039-a250-e00615deaba8"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("8d529d57-aa5b-4933-a8e4-69af0c23dc3d"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("8ac058a7-56b7-48d7-97ff-ec5b76e300cd"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("073c797f-f00a-4839-a304-6701bc54ff7c"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("b4e928a3-c1bd-487f-bc16-27f47cd3686c"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("88758f96-7b59-4732-b3cf-7393ea1f207d"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("a160ead0-9d33-48c6-b386-d0d928ea7d98"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("f72643b0-2bf3-44aa-a633-b54d8664bf79"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("f8b514b3-9042-4d62-8e8f-56aa3da601f9"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("a5bb6229-33ab-47ec-aec4-a8b39465cb26"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("ba99d061-3606-4b90-9d8a-832fc875219b"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("28cd6507-08bc-43ac-8281-bacfff3d3e0b"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("62a45d40-77e4-4114-886f-e3b676879182"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("e1f7fdc7-e0f8-4576-b533-bd3903f0e75d"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("ff212027-c77f-4b4d-9482-dfab35864e6c"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("00ef1990-fc32-4443-b0f7-3cf6fe616e9c"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("8d1eb870-abfa-49d3-832f-2d37535450cf"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("993c1b2c-15f7-42ff-8de1-11df9dd65871"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("1f99fdda-caed-49a4-98e3-a326eb2211f6"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("e99e8099-f18e-4d98-85b2-863fa735aba5"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("666166ff-ae91-4e79-9af6-2d07cdd375e2"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("9292fb9f-c1e5-4422-9e87-e74ef757855c"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("169a24f1-8a3a-4fff-af74-84a55f736d4d"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("6f56d9eb-b9e3-4ffb-809d-e42b72dca614"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("6f869be9-4a42-46e3-b676-88260d571c3c"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("923cb8cd-4f25-4fee-90ae-92efe6f13af5"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("22f3582d-6d6d-4976-933c-495b127059f1"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)13 },
                    { new Guid("baa48a4d-dcba-42f8-aa44-1d82dfbd1bd8"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)14 },
                    { new Guid("97c927b7-d0de-4b3d-a946-b10de2623683"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("c1239271-2fef-4eee-ba34-d90bd879d34f"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("98da052e-7a88-4302-a516-ff5d29ea0519"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("7cb37fa0-e0db-4151-b318-313861053f04"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("ba10cf24-3aae-427a-a44a-7159eec9f14a"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("f2e1b2a3-552e-42e6-a5b2-ed04579dcba8"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("e7636d9d-280b-4db0-aba0-27471b863663"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("cbad9dd5-d5ea-4e0e-bd6a-c5e0ac5cca95"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("fa9a412c-730b-44e8-b339-c3ede75007ef"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("37bcc307-9630-4b03-9d70-58dbe3784a10"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("f3d3f6b8-bb22-4957-935e-147fa2ef4c50"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("8690ed4d-5197-4c38-97df-75b6d1d1d9f4"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("167c782e-8c02-48e2-9d52-6599e260d690"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("16ad723d-1be2-4294-8df3-87293d3f86c8"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("416c6b3a-d300-4ea2-83ea-163a59e42126"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("b4c81661-53d0-48aa-8314-d52bd5aca94a"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("902f998e-d426-4af9-b4fb-0aeb798b8075"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("97e4b0d1-b5b9-4356-8467-4ac637fc141f"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("6a3c14e2-104a-401e-b452-6128077ecf14"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("15bbe6c2-3d15-4c71-bcd3-923aa32a5f13"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("1a7e558c-dcc7-45de-a78a-fa583a756e2a"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 },
                    { new Guid("3a864235-a2ea-4fa4-ae6d-8d267e291638"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("21adf502-4101-4845-b0a3-81458959d6ea"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("a8887ee0-7d9a-48ba-a1ae-74f49841ef42"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("ad326821-89f4-41c7-9b91-fef755ae07e5"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("b126e670-5e2b-42d8-8e83-dccf4a313131"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("926453aa-50a2-450f-82ac-7d646d41fb60"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("59cc355e-a082-4d6c-851d-b66ea60db14f"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)8 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "ID", "Column", "HallID", "Row" },
                values: new object[,]
                {
                    { new Guid("f0b9aa9b-9942-4d51-a2ed-975a153d81c3"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("84a85a32-71ae-47bd-9d46-661c3d785bbe"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("9d5b0523-48be-47c8-8736-44f13d450cd8"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("302d0c47-72ab-4786-ab0d-22f373e34c09"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("506ca5f2-52ae-4267-92e5-307c818e8407"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)11 },
                    { new Guid("3d099d29-e40e-460a-af9b-16c76d3a11a3"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("b074a7d0-715c-45d2-bb6f-7d6b9d5489f0"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("58d6b73e-cf6e-4275-af18-efa2d1d49c4b"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("7334a767-7fff-4ca8-b0c2-9c962aaa9c6e"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("dd7665cf-0dcd-40e0-a98e-267cfdca718c"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("9ae32b46-85a1-436c-b3a5-5248a0a95831"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("e96daec6-8ea7-4d20-9a88-619f72242722"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("6e29f7b0-9121-457e-a8c7-62ea82cbf00d"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("f15bc013-96d2-42b7-b4cf-f733b85eab4d"), (short)6, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("a754f9f6-23ed-428e-8284-ea9af0959f0b"), (short)5, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("927b1306-c2c5-444e-9df0-d9431a7c5900"), (short)4, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("646fd7d0-8b71-4df3-a823-952addd23dcb"), (short)3, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("a75d68ca-e1a0-462e-8436-a847b7463fee"), (short)2, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("bc3eec00-5006-45ed-8f27-1de3d858091e"), (short)1, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("a05737fd-1848-4a14-ae69-2be9a91b53b8"), (short)0, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)10 },
                    { new Guid("4130b4ef-521a-487a-9877-b7f7bf159726"), (short)14, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("e368e503-cb8c-4849-b225-9a3a4c2b91d3"), (short)13, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("cd1550b3-7ea5-4f43-ae9a-cbb55cc4a0ba"), (short)12, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("07dc5d82-6c7f-4fbe-bfd0-87b5ffd11b43"), (short)11, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("d540fe47-c8fc-464b-9e11-4afb86ac11fb"), (short)10, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("7f169236-f63a-438f-b189-58fedeb9f91d"), (short)9, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("6bf4db88-3c14-450b-b731-8ee03330c214"), (short)8, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("a41f1e9b-9bf1-4fb5-b603-8dc4879a74b9"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)9 },
                    { new Guid("dd0c4f79-f59f-4380-a03c-1c6530f76e4d"), (short)7, new Guid("e9ac61ba-8acd-456e-bfba-d4e4dc1ae9ec"), (short)7 },
                    { new Guid("718302a0-6b59-4d13-b1d7-b5f43fa655ea"), (short)14, new Guid("03d81cff-daf0-48b1-89f7-76bb5847c286"), (short)14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_HallID",
                table: "Events",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HallID",
                table: "Seats",
                column: "HallID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventID",
                table: "Tickets",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatID",
                table: "Tickets",
                column: "SeatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Halls");
        }
    }
}
