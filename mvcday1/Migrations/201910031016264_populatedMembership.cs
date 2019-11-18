namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatedMembership : DbMigration
    {
        public override void Up()
        {
            Sql("Insert MemberShipTypes(Type,Duration,SignUpFee,Discount) values('Yearly',12,1200,20)");
            Sql("Insert MemberShipTypes(Type,Duration,SignUpFee,Discount) values('Half-Yearly',6,600,15)");
            Sql("Insert MemberShipTypes(Type,Duration,SignUpFee,Discount) values('Quarterly',3,300,10)");
            Sql("Insert MemberShipTypes(Type,Duration,SignUpFee,Discount) values('PayAsYouWish',0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
