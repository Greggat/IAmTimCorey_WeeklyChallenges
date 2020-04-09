CREATE VIEW [dbo].[PeopleToShopFor]
	AS 
	SELECT [p].[Id], [p].[FirstName], [p].[LastName], [p].[Relation], [p].[GiftId], 
		[a].[Id] as ResidenceId, [a].[StreetAddress], [a].[City], [a].[State], [a].[ZipeCode]
	FROM dbo.Person p
	left join dbo.Residence a on p.ResidenceId = a.Id
	WHERE GiftId = -1
