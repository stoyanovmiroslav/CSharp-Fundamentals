﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters = new List<Harvester>();
    private List<Provider> providers = new List<Provider>();

    private string mode = "Full";
    private double totalMinedOre = 0;
    private double totalStoredEnergy = 0;

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
        }
        catch (ArgumentException argEx)
        {
            return argEx.Message;
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Provider providerSolar = ProviderFactory.CreateProvider(arguments);
            providers.Add(providerSolar);

        }
        catch (ArgumentException argEx)
        {
            return argEx.Message;
        }

        return $"Successfully registered {type} Provider - {id}";
    }


    public string Day()
    {
        double orePerDay = 0;
        double harvestersNeededEnergyPerDay = 0;
        double energyPerDay = providers.Sum(p => p.EnergyOutput);

        totalStoredEnergy += energyPerDay;

        harvestersNeededEnergyPerDay += harvesters.Sum(p => p.EnergyRequirement);

        if (totalStoredEnergy >= harvestersNeededEnergyPerDay)
        {
            if (mode == "Full")
            {
                orePerDay += harvesters.Sum(p => p.OreOutput);
                totalStoredEnergy -= harvestersNeededEnergyPerDay;
            }
            else if (mode == "Half")
            {
                orePerDay += harvesters.Sum(p => p.OreOutput * 0.5);
                totalStoredEnergy -= harvestersNeededEnergyPerDay * 0.6;
            }

            totalMinedOre += orePerDay;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyPerDay}");
        sb.AppendLine($"Plumbus Ore Mined: {orePerDay}");
        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string newMode = arguments[0];
        this.mode = newMode;

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (harvesters.Any(h => h.Id == id))
        {
            var harvest = harvesters.FirstOrDefault(h => h.Id == id);
            return harvest.ToString();
        }
        else if (providers.Any(p => p.Id == id))
        {
            var provide = providers.FirstOrDefault(p => p.Id == id);

            string name = "";

            if (provide.GetType().Name == "SolarProvider")
            {
                name = "Solar";
            }
            else if (provide.GetType().Name == "PressureProvider")
            {
                name = "Pressure";
            }

            string result = $"{name} Provider - {provide.Id}{Environment.NewLine}Energy Output: {provide.EnergyOutput}";
            return result;
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        string result = $"System Shutdown{Environment.NewLine}Total Energy Stored: {this.totalStoredEnergy}{Environment.NewLine}Total Mined Plumbus Ore: {this.totalMinedOre}";
        return result;
    }
}