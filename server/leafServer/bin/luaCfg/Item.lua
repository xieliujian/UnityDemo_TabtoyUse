-- Generated by github.com/davyxu/tabtoy
-- Version: 2.9.0

local tab = {
	Item = {
		{ ID = 100, Name = "1级药品", Desc = "1级药品" 	},
		{ ID = 101, Name = "2级药品", Desc = "2级药品" 	},
		{ ID = 102, Name = "3级药品", Desc = "3级药品" 	},
		{ ID = 103, Name = "4级药品", Desc = "4级药品" 	},
		{ ID = 104, Name = "5级药品", Desc = "5级药品" 	}
	}

}


-- ID
tab.ItemByID = {}
for _, rec in pairs(tab.Item) do
	tab.ItemByID[rec.ID] = rec
end

tab.Enum = {
}

return tab